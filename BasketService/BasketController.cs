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
            return Results.Created($"/{basket.id}", basket);
        }
        
        
    }
}