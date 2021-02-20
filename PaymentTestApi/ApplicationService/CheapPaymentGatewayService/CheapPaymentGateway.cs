using MediSmartTestApi.Utilities;
using PaymentTestApi.ApplicationService.ProcessPayment;
using PaymentTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        private readonly IProcessPaymentService _processPaymentService;
        public CheapPaymentGateway(IProcessPaymentService processPaymentService)
        {
            _processPaymentService = processPaymentService;
        }

        public string GatewayName = "Cheap Payment Gateway";

        public async Task<bool> ProcessPayment(PaymentRequest paymentRequest)
        {

            var result = await _processPaymentService.ProcessPayment(paymentRequest, GatewayName);
            return result;

        }
    }
}
