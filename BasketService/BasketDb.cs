using Microsoft.EntityFrameworkCore;

public class BasketDb : DbContext
{
    public BasketDb(DbContextOptions<BasketDb> options) : base(options) { }
    public DbSet<Basket> Baskets {get; set;}

    public DbSet<Item> BasketItems {get; set;}

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>()
            .HasMany(b => b.BasketItems)
            .WithOne();

            
            

        // modelBuilder.Entity<Basket>()
        //     .Navigation(basket => basket.BasketItems)
        //     .UsePropertyAccessMode(PropertyAccessMode.Property);

    }
    
        
    public BasketDb()
    {

    }


}