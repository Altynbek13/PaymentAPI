using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Dtos;
using PaymentAPI.Interfaces;

namespace PaymentAPI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet("payment")]
        public async Task<IActionResult> GetAll()
        {
            var payment= await _paymentService.GetAll();
            return Ok(payment);
        }        
        [HttpGet("payment/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = await _paymentService.GetById(id);
            if (payment ==null )
            {
                return NotFound();
            }
            return Ok(payment);
        }
        [HttpPost("payment")]
        public async Task<IActionResult> Create([FromBody]PaymentDetailsDto payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createId = await _paymentService.Create(payment);
            return CreatedAtAction(nameof(GetById),new {id= createId},payment);
        }
        [HttpPut("payment/{id}")]
        public async Task<IActionResult> Update([FromBody]PaymentDetailsDto payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _paymentService.Update(payment);
             return NoContent();
        }
        [HttpDelete("payment")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentService.Delete(id);
            return NoContent();

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
