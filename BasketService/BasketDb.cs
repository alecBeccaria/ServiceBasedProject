using Microsoft.EntityFrameworkCore;

public class BasketDb : DbContext
{
    public BasketDb(DbContextOptions<BasketDb> options) : base(options) { }
    public DbSet<Basket> Baskets {get; set;}

    public DbSet<Item> Items {get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>()
            .HasMany(b => b.Items)
            .WithOne(i => i.Basket).IsRequired(false)
            .HasForeignKey(i => i.BasketId);

        
        // modelBuilder.Entity<Basket>()
        //     .Navigation(basket => basket.BasketItems)
        //     .UsePropertyAccessMode(PropertyAccessMode.Property);
    }
    
        
    public BasketDb()
    {

    }


}