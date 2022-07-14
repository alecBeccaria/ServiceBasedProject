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
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public long? Quantity { get; set; }

        [JsonIgnore]
        public virtual List<Basket>? Baskets { get; set; }
    }

}