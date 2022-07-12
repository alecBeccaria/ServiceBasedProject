
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


public class Basket
{
    public int Id { get; set; }
    public int UserId {get; set;} 
    
    public List<Item> BasketItems {get; set;} = default!;
}




public class Item
{
    
    public int ItemId {get; set;}

    //public Basket Basket {get; set;}
    //Navigation Property
}


