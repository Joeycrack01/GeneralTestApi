using PaymentTestApi.ApplicationService.ProcessPaymentProvider;
using PaymentTestApi.Base;
using PaymentTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.ExpensivePaymentGatewayService
{

    public class ExpensivePaymentGatewayProvider : IPaymentProcessorProvider
    {
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        public ExpensivePaymentGatewayProvider(IExpensivePaymentGateway expensivePaymentGateway)
        {
            _expensivePaymentGateway = expensivePaymentGateway;
        }

        string IServiceBase.GatewayName => "Expensive Payment Gateway";

        decimal IServiceBase.MinAmount => 21.00m;

        decimal IServiceBase.MaxAmount => 500.00m;

        bool IServiceBase.isAvailable => true;

        public async Task<bool> ProcessPayment(PaymentRequest paymentRequest)
        {
            var result = await _expensivePaymentGateway.ProcessPayment(paymentRequest);
            return result;
        }
    }
}
