using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebLottery.Application.Contracts.Currency;
using WebLottery.Application.Contracts.Draw;
using WebLottery.Application.Contracts.Pocket;
using WebLottery.Application.Contracts.PocketTicket;
using WebLottery.Application.Contracts.Prize;
using WebLottery.Application.Contracts.Ticket;
using WebLottery.Application.Contracts.User;
using WebLottery.Application.Contracts.Wallet;
using WebLottery.Application.Contracts.WalletCurrency;
using WebLottery.Application.Currency;
using WebLottery.Application.Draw;
using WebLottery.Application.Pocket;
using WebLottery.Application.PocketTicket;
using WebLottery.Application.Prize;
using WebLottery.Application.Ticket;
using WebLottery.Application.User;
using WebLottery.Application.Wallet;
using WebLottery.Application.WalletCurrency;
using WebLottery.Infrastructure.Entities.User;
using WebLottery.Infrastructure.Implementations.Abstractions;
using WebLottery.Infrastructure.Implementations.DataContext;
using WebLottery.Infrastructure.Implementations.Jwt;
using WebLottery.Presentation.Extensions;
using WebLottery.Presentation.ProjectMapper;

namespace WebLottery.Presentation;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(
        IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(
                new SlugifyParameterTransformer()));
            options.Filters.Add(new ErrorFilter());
        });

        services.AddHttpContextAccessor();

        services.Configure<JwtOptions>(_configuration.GetSection(nameof(JwtOptions)));
        services.AddOptions();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebLottery API", Version = "v1" });
        });

        services.AddDbContext<DataContext>(options =>
        {
            options
                .UseNpgsql(_configuration.GetConnectionString("DefaultConnection"),
                    assembly =>
                        assembly.MigrationsAssembly("WebLottery.Infrastructure.Migrations"));
            options.UseTriggers(triggerOptions =>
            {
                triggerOptions.AddTrigger<EntityTrigger>();
            });
        });

        services.AddAutoMapper(typeof(AppMappingProfile));
        
        services.AddApiAuthentication(_configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>());

        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IDrawService, DrawService>();
        services.AddTransient<IPrizeService, PrizeService>();
        services.AddTransient<ICurrencyService, CurrencyService>();
        services.AddTransient<IPocketService, PocketService>();
        services.AddTransient<IPocketTicketService, PocketTicketService>();
        services.AddTransient<ITicketService, TicketService>();
        services.AddTransient<IWalletService, WalletService>();
        services.AddTransient<IWalletCurrencyService, WalletCurrencyService>();
        services.AddScoped<IDbRepository, DbRepository>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddSingleton(new UserEntity { Id = 0 });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
    {
        app.UseRouting();

        app.UseSwagger();
        app.UseSwaggerUI(x =>
        {
            x.SwaggerEndpoint("/swagger/v1/swagger.json", "WebLottery API v1");
            x.RoutePrefix = "swagger";
        });

        app.UseCookiePolicy(new CookiePolicyOptions
        {
            MinimumSameSitePolicy = SameSiteMode.Strict,
            HttpOnly = HttpOnlyPolicy.Always,
            Secure = CookieSecurePolicy.Always
        });
        
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value) =>
            value is null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
    }

    public class ErrorFilter : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            var response = $"{{\"error\": \"{exception.Message}{exception.InnerException?.Message}\"}}";
            await using var responseWriter = new StreamWriter(context.HttpContext.Response.Body, Encoding.UTF8);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.HttpContext.Response.ContentType = "application/json; charset=utf-8";
            context.HttpContext.Response.ContentLength = Encoding.UTF8.GetBytes(response).Length + 3;
            await responseWriter.WriteAsync(response);
        }
    }
}