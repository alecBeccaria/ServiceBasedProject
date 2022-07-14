using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BasketService
{
    [ApiController]
    [Route("basket")]
    public class BasketsController : Controller
    {

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
        public async Task<IResult> CreateBasket(Basket basket)
        {

            _db.Baskets.Add(basket);
            await _db.SaveChangesAsync();
            return Results.Created($"/Id: {basket.Id}", basket);
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

           /* if(item.Baskets is null)
            {
                item.Baskets = new List<Basket>(); 
            }*/

            if (basket.Items is null)
            {
                basket.Items = new List<Item>();
            }

            //item.Baskets.Add(basket);

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

            if(basket.Items == null || basket.Items.Contains(item))
            {
                return Results.Ok("Item not in list");
            }



            basket.Items.Find(i => i.Id == item.Id);


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