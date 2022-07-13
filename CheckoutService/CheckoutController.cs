using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers{

    [ApiController]
    [Route("checkoutservice")]
    public class CheckoutController : ControllerBase{
        private readonly CheckoutDB _db;

        public CheckoutController(ILogger<CheckoutController> logger, CheckoutDB db)
        {            
            _db = db;
        }
        //Post / (accepts order return orderID) //Finished Order
        [HttpPost]
        public IActionResult Post([FromBody] CheckoutOrder order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            _db.Checkouts.Add(order);
            _db.SaveChanges();
            return Ok(order);
        }
        //Get / (return collection of orders)
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Checkouts);
        }
        //Get /{id} (returns order with id)
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var order = _db.Checkouts.FirstOrDefault(o => o.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        //Get /{userID} (return collection of orders)
        [HttpGet]
        [Route("user/{userID}")]
        public IActionResult Get(int userID)
        {
            Console.WriteLine("userID: " + userID);
            return Ok(_db.Checkouts.Where(o => o.userID == userID));
        }
        //delete orderID
        [HttpDelete("{orderID}")]
        public IActionResult Delete(int orderID)
        {
            var order = _db.Checkouts.FirstOrDefault(o => o.ID == orderID);
            if (order == null)
            {
                return NotFound();
            }
            _db.Checkouts.Remove(order);
            _db.SaveChanges();
            return Ok(order);
        }
    }
}