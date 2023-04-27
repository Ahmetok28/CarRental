using Bussines.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        //[HttpGet("payment")]
        //public IActionResult Payment() 
        //{
        //    //var result = _paymentService.Pay();
        //    //if (result.Success)
        //    //{
        //    //    return Ok(result);
        //    //}

        //    //return BadRequest(result);
        //}
    }
}
