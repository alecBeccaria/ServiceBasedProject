using Microsoft.EntityFrameworkCore;
public class CheckoutDB : DbContext
{

    public CheckoutDB(DbContextOptions<CheckoutDB> options) : base(options) { }
    public DbSet<CheckoutOrder> Checkouts => Set<CheckoutOrder>();
    
    public CheckoutDB()
    {

    }
    
}
