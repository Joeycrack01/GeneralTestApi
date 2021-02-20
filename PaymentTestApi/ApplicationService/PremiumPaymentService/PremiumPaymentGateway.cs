using PaymentTestApi.ApplicationService.ProcessPayment;
using PaymentTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.PremiumPaymentService
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway
    {
        private readonly IProcessPaymentService _processPaymentService;
        public PremiumPaymentGateway(IProcessPaymentService processPaymentService)
        {
            _processPaymentService = processPaymentService;
        }

        public string GatewayName = "Premium Payment Gateway";

        public async Task<bool> ProcessPayment(PaymentRequest paymentRequest)
        {

            var result = await _processPaymentService.ProcessPayment(paymentRequest, GatewayName);
            return result;

        }
    }
}
