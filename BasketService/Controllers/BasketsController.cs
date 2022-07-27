using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BasketService
{
    [ApiController]
    [Route("basket")]
    public class BasketsController : Controller
    {

        [HttpGet]
        [Route("test")]
        public ActionResult<String> abc() {
            return "Hello from test";
        }
        [HttpGet]
        [Route("container")]
        public ActionResult<String> ContainerResponse() {
            string myHost = System.Net.Dns.GetHostName();
            string myIP = System.Net.Dns.GetHostEntry(myHost).AddressList[0].ToString();
            return "Hello from container: " + myHost + " " + myIP;
        }

        private readonly BasketDb _db;
        public BasketsController(ILogger<BasketsController> logger, BasketDb db)
        {
            _db = db;
        }

        //Get all Baskets
        [HttpGet("all")]
        public async Task<ActionResult<List<Basket>>> AllBaskets()
        {
            var list = await _db.Baskets.Include(b => b.Items).ToListAsync();
            return Ok(list);
        }



        //Get One Basket
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Basket>>> SingleBasket(int id)
        {
            var todo = await _db.Baskets.Include(b => b.Items).FirstAsync(b => b.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        //Create Basket for User
        [HttpPost("add")]
        public async Task<ActionResult<Basket>> AddBasket(Basket basket)
        {
            //Adds basket
            //check if basket exists
            
            
            await _db.Database.ExecuteSqlRawAsync(
            $"INSERT INTO Baskets (userId) VALUES({basket.userId});");

            List<Basket> dbBasketList = await _db.Baskets.ToListAsync();
            int currentBasketId = dbBasketList.Count();



            if (basket.Items != null)
            {
                List<Item> itemsDb = await _db.Items.ToListAsync();

                foreach (Item item in basket.Items)
                {
                    if (itemsDb.Contains(item))
                    {
                        await _db.Database.ExecuteSqlRawAsync($"INSERT INTO Items(Id, Title, Description, Price, Quantity) VALUES({item.Id}, '{item.Title}','{item.Description}',{item.Price},{item.Quantity});");
                    }

                    await _db.Database.ExecuteSqlRawAsync($"INSERT INTO BasketItem VALUES({currentBasketId},{item.Id});");
                    
                }
            }
            await _db.SaveChangesAsync();
            return Ok(basket);
        }


        //Add Item to specified basket {id}
        [HttpPut("{id}/item/add")]
        public async Task<IResult> AddOneToBasket(Item item, int id)
        {

            var basket = await _db.Baskets.Include(b => b.Items).FirstAsync(b => b.Id == id);

            var itemDb = await _db.Items.FindAsync(item.Id);

            if (itemDb != null)
            {
                item = itemDb;
            }

            if (basket is null)
            {
                return Results.NotFound();
            }


            if (basket.Items is null)
            {
                basket.Items = new List<Item>();
            }


            if (basket.Items.Contains(item))
            {
                return Results.BadRequest($"Item already exists.");
            }

            basket.Items.Add(item);

            _db.Baskets.Update(basket);

            await _db.SaveChangesAsync();

            return Results.Ok(basket);
        }

        [HttpDelete("{id}/item")]
        public async Task<IResult> deleteItem(Item item, int id)
        {
            Basket basket = await _db.Baskets.Include(b => b.Items).FirstAsync(basket => basket.Id == id);

            if(basket == null)
            {
                return Results.NotFound($"Basket with id {id} does not exist");
            }

            if(basket.Items == null)
            {
                return Results.Ok("Item not in list");
            }

            Item ItemToRemove = basket.Items.Find(i => i.Id == item.Id);

            if(ItemToRemove == null)
            {
                return Results.Ok("Item not in list");
            }

            basket.Items.Remove(ItemToRemove);

            _db.Baskets.Update(basket);
            
            
            await _db.SaveChangesAsync();

            return Results.Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> deleteBasket(int id)
        {
            Basket basket = await _db.Baskets.Include(b => b.Items).FirstAsync(basket => basket.Id == id);

            if (basket == null)
            {
                return Results.NotFound($"Basket with id {id} does not exist");
            }


            _db.Baskets.Remove(basket);
            await _db.SaveChangesAsync();

            return Results.Ok($"Basket {basket.Id} has been removed");
        }



    }
}