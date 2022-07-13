using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers{

    [ApiController]
    [Route("userservice")]
    public class MyController : ControllerBase{
        private readonly UserDB _db;

        public MyController(ILogger<MyController> logger, UserDB db)
        {            
            _db = db;
        }

        [HttpGet]
        [Route("abc")]
        public ActionResult<string> abc(){
            return "Hello World!";
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByID(long id){
            var user = await _db.Users.FindAsync(id);
            if(user == null){
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("payment/{id}")]
        public async Task<ActionResult<User>> GetUserByPayment(long id){
            var user = await _db.Users.FindAsync(id);
            if(user == null){
                return NotFound();
            }
            return Ok(user.CardID);
        }

        [HttpPut]
        public async Task<ActionResult<User>> AddPaymentToUser(int cardID, long userID){
            var user = await _db.Users.FindAsync(userID);
            if(user == null){
                return NotFound();
            }
            user.CardID = cardID;
            await _db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IResult> PostUser(User user){
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return Results.Created($"/{user.Id}", user);   
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(long id){
            var user = await _db.Users.FindAsync(id);
            if(user == null){
                return NotFound();
            }
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }
    }
}