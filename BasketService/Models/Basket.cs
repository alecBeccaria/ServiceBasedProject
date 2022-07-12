
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


public class Basket
{
    public int Id { get; set; }
    public int UserId {get; set;} 
    
    public virtual ICollection<Item> Items {get; set;}
}


public class Item
{
    public int Id {get; set;}

    
    public int BasketId {get; set;}
    public virtual Basket Basket {get; set;}

    //public Basket Basket {get; set;}
    //Navigation Property
}

public class BasketItem 
{
    public ICollection<Item> item {get; set;}
    public Basket basket {get; set;}
}



