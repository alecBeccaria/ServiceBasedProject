using Microsoft.EntityFrameworkCore;
using BasketService;


public class BasketDb : DbContext
{
    public BasketDb(DbContextOptions<BasketDb> options) : base(options) { }
    public DbSet<Basket> Baskets { get; set; }

    public DbSet<Item> Items { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
        modelBuilder.Entity<Item>().Property(item => item.Id).ValueGeneratedNever();

        /*modelBuilder.Entity<BasketItem>()

        modelBuilder.Entity<Basket>()
            .HasMany(basket => basket.Items)
            .WithMany(item => item.Baskets).UsingEntity(BasketItems.GetType());*/
    }


}
