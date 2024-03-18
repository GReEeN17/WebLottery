using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Extensions.Configuration;
using WebLottery.Infrastructure.Entities.Entities;
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
        
        modelBuilder.Entity<CurrencyEntity>().Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();

        modelBuilder.ApplyConfiguration(new CurrencyConfiguration());

        #endregion

        #region DrawEntity config
        
        modelBuilder.Entity<DrawEntity>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();

        modelBuilder.ApplyConfiguration(new DrawConfiguration());

        #endregion

        #region PocketEntity config
        
        modelBuilder.Entity<PocketEntity>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();

        modelBuilder.ApplyConfiguration(new PocketConfiguration());

        #endregion

        #region PocketTicketEntity config
        
        modelBuilder.Entity<PocketTicketEntity>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();

        modelBuilder.ApplyConfiguration(new PocketTicketConfiguration());

        #endregion

        #region PrizeEntity config
        
        modelBuilder.Entity<PrizeEntity>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();

        modelBuilder.ApplyConfiguration(new PrizeConfiguration());

        #endregion

        #region TicketEntity config
        
        modelBuilder.Entity<TicketEntity>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();

        modelBuilder.ApplyConfiguration(new TicketConfiguration());

        #endregion

        #region UserEntity config
        
        modelBuilder.Entity<UserEntity>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();

        modelBuilder.ApplyConfiguration(new UserConfiguration());

        #endregion

        #region WalletEntity config
        
        modelBuilder.Entity<WalletEntity>()
            .Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();

        modelBuilder.ApplyConfiguration(new WalletConfiguration());

        #endregion

        #region WalletCurrencyEntity config

        modelBuilder.Entity<WalletCurrencyEntity>().Property(pm => pm.Id)
            .HasValueGenerator<GuidValueGenerator>();

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