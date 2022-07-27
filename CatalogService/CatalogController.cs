using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [ApiController]
    [Route("catalog")]
    public class MyController : ControllerBase
    {
        private readonly ItemDb _db;
        private List<Item> catalog = new List<Item>();

        public MyController(ILogger<MyController> logger, ItemDb db)
        {            
            _db = db;
        }

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

        [HttpGet]
        [Route("items")]
        public async Task<ActionResult<List<Item>>> GetAllItems() {

            return await _db.Items.ToListAsync();
        }

        [HttpGet]
        [Route("items/search/{min}/{max}")]
        public async Task<List<Item>> GetAllCompletedItems(long min, long max) {
            return await _db.Items.Where(i => i.Price > min && i.Price < max).ToListAsync();
        }

        [HttpGet]
        [Route("items/search/{search}")]
        public async Task<List<Item>> GetAllCompletedItems(string search) {
            return await _db.Items.Where(i => i.Title.Contains(search) || i.Description.Contains(search)).ToListAsync();;
        }

        [HttpGet]
        [Route("items/{id}")]
        public async Task<ActionResult<Item>> GetItem(long id) {
            var item = await _db.Items.FindAsync(id);
            if (item == null) {
                return NotFound();
            }
            
            return Ok(item);
        }

        [HttpPost]
        [Route("items")]
        public async Task<IResult> PostItem(Item item) {
            _db.Items.Add(item);
            await _db.SaveChangesAsync();

            return Results.Created($"/{item.Id}", item);
        }

        [HttpPut]
        [Route("items")]
        public async Task<IResult> PutItem(Item item1) {
            var item2 = await _db.Items.FindAsync(item1.Id);

            if (item2 == null) {
                return Results.NotFound();
            }

            item2.Title = item1.Title;
            item2.Description = item1.Description;
            item2.Price = item1.Price;
            item2.Quantity = item1.Quantity;

            await _db.SaveChangesAsync();

            return Results.NoContent();
        }

        [HttpDelete("items/{id}")]
        public async Task<IResult> DeleteItem(long id) {
            if (await _db.Items.FindAsync(id) is Item item) {
                _db.Items.Remove(item);
                await _db.SaveChangesAsync();
                return Results.Ok(item);
            }

            return Results.NotFound();
        }
    }
}