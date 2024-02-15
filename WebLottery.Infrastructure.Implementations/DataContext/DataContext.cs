using Microsoft.EntityFrameworkCore;
using WebLottery.Infrastructure.Entities.Currency;
using WebLottery.Infrastructure.Entities.Draw;
using WebLottery.Infrastructure.Entities.Pocket;
using WebLottery.Infrastructure.Entities.PocketTicket;
using WebLottery.Infrastructure.Entities.Prize;
using WebLottery.Infrastructure.Entities.Ticket;
using WebLottery.Infrastructure.Entities.User;
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
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<WalletEntity> Wallets { get; set; }
    public DbSet<WalletCurrencyEntity> WalletCurrencies { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence<int>("currency_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(99999999999999999);
        
        modelBuilder.HasSequence<int>("draw_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(99999999999999999);
        
        modelBuilder.HasSequence<int>("pocket_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(99999999999999999);
        
        modelBuilder.HasSequence<int>("pocket_ticket_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(99999999999999999);
        
        modelBuilder.HasSequence<int>("prize_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(99999999999999999);
        
        modelBuilder.HasSequence<int>("ticket_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(99999999999999999);
        
        modelBuilder.HasSequence<int>("user_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(99999999999999999);
        
        modelBuilder.HasSequence<int>("wallet_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(99999999999999999);
        
        modelBuilder.HasSequence<int>("wallet_currency_sequence")
            .StartsAt(1)
            .IncrementsBy(1)
            .HasMin(1)
            .HasMax(99999999999999999);

        #region CurrencyEntity config

        modelBuilder.Entity<CurrencyEntity>().Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"currency_sequence\"')");

        #endregion

        #region DrawEntity config

        modelBuilder.Entity<DrawEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"draw_sequence\"')");

        #endregion

        #region PocketEntity config

        modelBuilder.Entity<PocketEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"pocket_sequence\"')");

        #endregion

        #region PocketTicketEntity config

        modelBuilder.Entity<PocketTicketEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"pocket_ticket_sequence\"')");

        #endregion

        #region PrizeEntity config

        modelBuilder.Entity<PrizeEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"prize_sequence\"')");

        #endregion

        #region TicketEntity config

        modelBuilder.Entity<TicketEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"ticket_sequence\"')");

        #endregion

        #region UserEntity config

        modelBuilder.Entity<UserEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"user_sequence\"')");

        #endregion

        #region WalletEntity config

        modelBuilder.Entity<WalletEntity>()
            .Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"wallet_sequence\"')");

        #endregion

        #region WalletCurrencyEntity config

        modelBuilder.Entity<WalletCurrencyEntity>().Property(pm => pm.Id)
            .HasDefaultValueSql("nextval('\"wallet_currency_sequence\"')");

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