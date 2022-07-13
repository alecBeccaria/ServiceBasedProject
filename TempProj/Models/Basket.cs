 public class Basket
{
    public int Id { get; set; }
    public int UserId {get; set;} 
    
    public List<Item> Items {get; set;} = default!; 
}


public class Item
{
    //Primary Key
    public int Id {get; set;}
}




