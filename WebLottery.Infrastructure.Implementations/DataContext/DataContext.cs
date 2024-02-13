using Microsoft.EntityFrameworkCore;
using WebLottery.Infrastructure.Entities.Currency;
using WebLottery.Infrastructure.Entities.Draw;
using WebLottery.Infrastructure.Entities.Pocket;
using WebLottery.Infrastructure.Entities.PocketTicket;
using WebLottery.Infrastructure.Entities.Prize;
using WebLottery.Infrastructure.Entities.Ticket;
using WebLottery.Infrastructure.Entities.User;
using WebLottery.Infrastructure.Entities.UserDraw;
using WebLottery.Infrastructure.Entities.Wallet;
using WebLottery.Infrastructure.Entities.WalletCurrency;

namespace WebLottery.Infrastructure.Implementations.DataContext;

public class DataContext : DbContext
{
    public DbSet<CurrencyEntity> Currencies { get; set; }
    public DbSet<DrawEntity> Draws { get; set; }
    public DbSet<PocketEntity> Pockets { get; set; }
    public DbSet<PocketTicketEntity> PocketTickets { get; set; }
    public DbSet<PrizeEntity> Prizes { get; set; }
    public DbSet<TicketEntity> Tickets { get; set; }
    public DbSet<UserEntity> Uesrs { get; set; }
    public DbSet<UserDrawEntity> UserDraws { get; set; }
    public DbSet<WalletEntity> Wallets { get; set; }
    public DbSet<WalletCurrencyEntity> WalletCurrencies { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
    
    public DbSet<T> DbSet<T>() where T : class
    {
        return Set<T>();
    }

    public new IQueryable<T> Query<T>() where T : class
    {
        return Set<T>();
    }
}