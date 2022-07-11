using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using 

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
        public async Task<IResult> CreateBasket(int userId)
        {
            Basket basket = new Basket(userId);
            _db.Baskets.Add(basket);
            await _db.SaveChangesAsync();
            return Results.Created($"/Id: {basket.Id}", basket);
        }

        [HttpPut("Add")]
        public async Task<IResult> AddOneToBasket(int itemId, Basket basket)
        {
            Basket taskbasket = getDbBasket(basket.Id);
            
            

            basket.AddItem(basket.Id, itemId);


            _db.Baskets.Update(basket);

            foreach (BasketItem item in basket.Items)
            {
                _db.BasketItems.Update(item);
            }

            await _db.SaveChangesAsync();

            return Results.Created($"Basket Id: {basket.Id}\nItem Id: {itemId}", basket);
        }

        public async Task<Basket> getDbBasket(int basketId)
        {
            
            List<BasketItem> items = await _db.BasketItems.Where(b => b.BasketId == basketId).ToListAsync();
            Basket basket = await _db.Baskets.FirstAsync(b => b.Id == basketId);
            
            basket.Items = items;
            

            return basket;
        }

        
        
    }
}