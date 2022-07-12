
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


public class Basket
{
    public int Id { get; set; }
    public int UserId {get; set;} 
    
    public ICollection<BasketItem> BasketItems {get; set;}
}


public class BasketItem
{
    
    public int ItemId {get; set;}

    public int BasketId {get;set;}
    //Navigation Property
    public Basket Basket {get; set;} = default!;

    
}


