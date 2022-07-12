
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


public class Basket
{
    public int Id { get; set; }
    public int UserId {get; set;} 
    
    public List<Item> Items {get; set;}
}


public class Item
{
    //Primary Key
    public int Id {get; set;}

    
    
}




