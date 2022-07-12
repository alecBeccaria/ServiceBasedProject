using Microsoft.EntityFrameworkCore;

public class BasketDb : DbContext
{
    public BasketDb(DbContextOptions<BasketDb> options) : base(options) { }
    public DbSet<Basket> Baskets {get; set;}

    public DbSet<BasketItem> BasketItems {get; set;}

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BasketItem>()
            
            .HasOne(item => item.Basket)
            .WithMany(Basket => Basket.BasketItems)
            .HasForeignKey(e => e.BasketId)
            .IsRequired(false);

            modelBuilder.Entity<BasketItem>().Property("BasketItems").IsRequired(false);
            

        // modelBuilder.Entity<Basket>()
        //     .Navigation(basket => basket.BasketItems)
        //     .UsePropertyAccessMode(PropertyAccessMode.Property);

    }
    
        
    public BasketDb()
    {

    }


}