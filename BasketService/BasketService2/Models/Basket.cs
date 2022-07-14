using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BasketService
{
    public class Basket
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public List<Item>? Items { get; set; }
    }


    public class Item
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [JsonIgnore]
        public virtual List<Basket>? Baskets { get; set; }
    }

    


}






