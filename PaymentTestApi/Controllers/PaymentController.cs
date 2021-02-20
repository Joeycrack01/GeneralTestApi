using MediSmartTestApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using PaymentTestApi.ApplicationService.ValidatePaymentRequest;
using PaymentTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTestApi.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : BaseApiController
    {
        private readonly IValidatePaymentRequest _validatePayment;
        public PaymentController(IValidatePaymentRequest validatePayment)
        {
            _validatePayment = validatePayment;
        }

        [HttpPost, Route("ProcessPayment")]
        public async Task<IActionResult> ProcessPayment(PaymentRequest paymentRequest)
        {
            try
            {
                var result = await _validatePayment.ValidatePayment(paymentRequest);

                if (!result) return BadRequest();

                return Ok();
            }
            catch (Exception ex)
            {
                LogError(ex);
                return StatusCode(500);
            }
        }
    }
}
