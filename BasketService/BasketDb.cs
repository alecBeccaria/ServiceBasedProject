using Microsoft.EntityFrameworkCore;
public class BasketDb : DbContext
{
    public BasketDb(DbContextOptions<BasketDb> options) : base(options) { }
    public DbSet<Basket> Baskets => Set<Basket>();
    
    public BasketDb()
    {

    }


}