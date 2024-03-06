using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebLottery.Infrastructure.Entities.Currency;
using WebLottery.Infrastructure.Entities.Draw;
using WebLottery.Infrastructure.Entities.Pocket;
using WebLottery.Infrastructure.Entities.PocketTicket;
using WebLottery.Infrastructure.Entities.Prize;
using WebLottery.Infrastructure.Entities.Ticket;
using WebLottery.Infrastructure.Entities.User;
using WebLottery.Infrastructure.Entities.Wallet;
using WebLottery.Infrastructure.Entities.WalletCurrency;
using WebLottery.Infrastructure.Implementations.Configuration;

namespace WebLottery.Infrastructure.Implementations.DataContext;

public class DataContext : DbContext
{
    public DbSet<CurrencyEntity> Currencies { get; set; }
    public DbSet<DrawEntity> Draws { get; set; }
    public DbSet<PocketEntity> Pockets { get; set; }
    public DbSet<PocketTicketEntity> PocketTickets { get; set; }
    public DbSet<PrizeEntity> Prizes { get; set; }
    public DbSet<TicketEntity> Tickets { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<WalletEntity> Wallets { get; set; }
    public DbSet<WalletCurrencyEntity> WalletCurrencies { get; set; }

    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region CurrencyEntity config
        
        modelBuilder.HasSequence<int>("currency_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(999999999);

        modelBuilder.Entity<CurrencyEntity>().Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"currency_sequence\"')");

        modelBuilder.ApplyConfiguration(new CurrencyConfiguration());

        #endregion

        #region DrawEntity config
        
        modelBuilder.HasSequence<int>("draw_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(999999999);

        modelBuilder.Entity<DrawEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"draw_sequence\"')");

        modelBuilder.ApplyConfiguration(new DrawConfiguration());

        #endregion

        #region PocketEntity config
        
        modelBuilder.HasSequence<int>("pocket_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(999999999);

        modelBuilder.Entity<PocketEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"pocket_sequence\"')");

        modelBuilder.ApplyConfiguration(new PocketConfiguration());

        #endregion

        #region PocketTicketEntity config
        
        modelBuilder.HasSequence<int>("pocket_ticket_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(999999999);

        modelBuilder.Entity<PocketTicketEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"pocket_ticket_sequence\"')");

        modelBuilder.ApplyConfiguration(new PocketTicketConfiguration());

        #endregion

        #region PrizeEntity config
        
        modelBuilder.HasSequence<int>("prize_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(999999999);

        modelBuilder.Entity<PrizeEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"prize_sequence\"')");

        modelBuilder.ApplyConfiguration(new PrizeConfiguration());

        #endregion

        #region TicketEntity config
        
        modelBuilder.HasSequence<int>("ticket_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(999999999);

        modelBuilder.Entity<TicketEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"ticket_sequence\"')");

        modelBuilder.ApplyConfiguration(new TicketConfiguration());

        #endregion

        #region UserEntity config
        
        modelBuilder.HasSequence<int>("user_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(999999999);

        modelBuilder.Entity<UserEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"user_sequence\"')");

        modelBuilder.ApplyConfiguration(new UserConfiguration());

        #endregion

        #region WalletEntity config
        
        modelBuilder.HasSequence<int>("wallet_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(999999999);

        modelBuilder.Entity<WalletEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"wallet_sequence\"')");

        modelBuilder.ApplyConfiguration(new WalletConfiguration());

        #endregion

        #region WalletCurrencyEntity config
        
        modelBuilder.HasSequence<int>("wallet_currency_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(999999999);

        modelBuilder.Entity<WalletCurrencyEntity>().Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"wallet_currency_sequence\"')");

        modelBuilder.ApplyConfiguration(new WalletCurrencyConfiguration());

        #endregion
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