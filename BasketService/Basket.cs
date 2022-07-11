
using Microsoft.AspNetCore.Mvc;
public class Basket{
    
    public int Id { get; set; }

    public int UserId {get; set;} 
    
    //Key = BasketId, Value = ItemId 
    public  List<BasketItem> Items {get; set;}

    public Basket(int userId)
    {
        UserId = userId;
        Items = new List<BasketItem>();
    }

    public void AddItem(int basketId, int itemId)
    {
        Items.Add(new BasketItem(basketId, itemId));
    }


}
