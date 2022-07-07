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
        public void GetBasketId(int id)
        {

        }
        
    }
}