using MediSmartTestApi.Utilities;
using PaymentTestApi.ApplicationService.ProcessPayment;
using PaymentTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.ExpensivePaymentGatewayService
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        private readonly IProcessPaymentService _processPaymentService;
        public ExpensivePaymentGateway(IProcessPaymentService processPaymentService)
        {
            _processPaymentService = processPaymentService;
        }

        public string GatewayName = "Expensive Payment Gateway";

        public async Task<bool> ProcessPayment(PaymentRequest paymentRequest)
        {

            var result = await _processPaymentService.ProcessPayment(paymentRequest, GatewayName);
            return result;
        }
    }
}
