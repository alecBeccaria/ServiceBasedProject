using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers{

    [ApiController]
    [Route("card")]
    public class CardController : ControllerBase{
        private readonly CardDB _db;

        public CardController(ILogger<CardController> logger, CardDB db)
        {            
            _db = db;
        }

        [HttpGet]
        [Route("test")]
        public ActionResult<String> abc() {
            return "Hello from test";
        }
        
        [HttpPost("add")]
        public IActionResult Post([FromBody]Card card)
        {
            if (card == null || !(VerifyCard(card)) ){ 
                return BadRequest(); 
            }
            _db.Cards.Add(card);
            _db.SaveChanges();
            return Ok(card);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Cards);
        }
        //verify card by id
        [HttpGet("verify/{id}")]
        public IActionResult Verify(long id)
        {
            var card = _db.Cards.Find(id);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(VerifyCard(card));
        }
        //find card by id
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var card = _db.Cards.Find(id);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }
        //delete card
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var card = _db.Cards.Find(id);
            if (card == null)
            {
                return NotFound();
            }
            _db.Cards.Remove(card);
            _db.SaveChanges();
            return Ok(card);
        }
        //update card by id
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Card card)
        {
            if (card == null || !(VerifyCard(card)) ){ 
                return BadRequest(); 
            }
            var cardToUpdate = _db.Cards.Find(id);
            if (cardToUpdate == null)
            {
                return NotFound();
            }
            cardToUpdate.CardNumber = card.CardNumber;
            cardToUpdate.ExpirationDate = card.ExpirationDate;
            cardToUpdate.CardCCV = card.CardCCV;
            _db.SaveChanges();
            return Ok(cardToUpdate);
        }
        public bool VerifyCard(Card card)
        {
            //TODO: Implement cardnumber verification



            //check if expiration date is valid
            try{
                DateTime expDate = DateTime.Parse(card.ExpirationDate);
                if (expDate < DateTime.Now)
                {
                    return false;
                }
            }
            catch(Exception e) {
                return false;
            }
            //check if CCV is valid
            if (card.CardCCV < 100 || card.CardCCV > 999)
            {
                return false;
            }
            return true;
        }

    }
}