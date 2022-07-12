
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


public class Basket
{
    
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId {get; set;} 
    
    //Key = BasketId, Value = ItemId 
    
    public  ICollection<BasketItem> Items {get; set;}

    public Basket(int userId)
    {
        UserId = userId;
        Items = new List<BasketItem>();
    }
}


public class BasketItem
{
    [Key]
    public int ItemId {get; set;}
    
    
    public  Basket Basket {get; set;}

}
