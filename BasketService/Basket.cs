
using System.ComponentModel.DataAnnotations;
public class Basket{
    
    public int id { get; set; } 
    
    public  Dictionary<int, int> items {get; set;}

   
    
}
