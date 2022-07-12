using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BasketController
{
    [ApiController]
    [Route("basket")]
    public class BasketController: ControllerBase
    {

        private readonly BasketDb _db;
        public BasketController(ILogger<BasketController> logger, BasketDb db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<String> abc()
        {
            return "Yes No idk";
        }

        [HttpPost]
        public async Task<IResult> CreateBasket(Basket basket)
        {
            
            _db.Baskets.Add(basket);
            await _db.SaveChangesAsync();
            return Results.Created($"/Id: {basket.Id}", basket);
        }

        [HttpPut]
        public async Task<ActionResult<Basket>> AddOneToBasket(int itemId, int BasketId)
        {
            List<BasketItem> items = await _db.BasketItems.Where(b => b.Basket.Id == BasketId).ToListAsync();
            Basket basket = await _db.Baskets.FirstAsync(b => b.Id == BasketId);


            _db.Baskets.Update(basket);

            foreach (BasketItem item in basket.Items)
            {
                _db.BasketItems.Update(item);
            }

            await _db.SaveChangesAsync();

            return Ok(basket);
        }

        
        
    }
}