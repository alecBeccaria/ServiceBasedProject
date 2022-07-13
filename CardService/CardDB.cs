using Microsoft.EntityFrameworkCore;
public class CardDB : DbContext
{

    public CardDB(DbContextOptions<CardDB> options) : base(options) { }
    public DbSet<Card> Cards => Set<Card>();
    
    public CardDB()
    {

    }
    
}
