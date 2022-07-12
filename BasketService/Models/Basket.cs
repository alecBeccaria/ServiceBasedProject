
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
    //Primary Key
    public int Id {get; set;}

    //Foreign key
    //public int BasketId {get; set;}

    //Navigation Prop
    public virtual Basket Basket {get; set;}

    
}




