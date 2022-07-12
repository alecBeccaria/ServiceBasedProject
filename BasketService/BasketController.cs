using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BasketController
{
    [ApiController]
    [Route("basket")]
    public class BasketController: Controller
    {

        private readonly BasketDb _db;
        public BasketController(ILogger<BasketController> logger, BasketDb db)
        {
            _db = db;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Basket>>> AllBaskets()
        {
            return await _db.Baskets.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Basket>>> AllBaskets(int id)
        {
            var todo = await _db.Baskets.FindAsync(id);
            if(todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IResult> CreateBasket(Basket basket)
        {
            
            _db.Baskets.Add(basket);
            await _db.SaveChangesAsync();
            return Results.Created($"/Id: {basket.Id}", basket);
        }

        [HttpPut]
        public async Task<IResult> AddOneToBasket(Basket basket)
        {
            _db.Baskets.Update(basket);
            await _db.SaveChangesAsync();
            return Results.Ok(basket);
        }

        
        
    }
}