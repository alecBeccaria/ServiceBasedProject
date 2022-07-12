using Microsoft.EntityFrameworkCore;

public class BasketDb : DbContext
{
    public BasketDb(DbContextOptions<BasketDb> options) : base(options) { }
    public DbSet<Basket> Baskets => Set<Basket>();

    public DbSet<BasketItem> BasketItems => Set<BasketItem>();

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>()
            .HasMany(basket => basket.Items)
            .WithOne(item => item.Basket);
    }
    
        
    public BasketDb()
    {

    }


}