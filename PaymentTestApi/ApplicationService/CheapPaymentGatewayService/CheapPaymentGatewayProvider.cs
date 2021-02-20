using PaymentTestApi.ApplicationService.ProcessPaymentProvider;
using PaymentTestApi.Base;
using PaymentTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.CheapPaymentGatewayService
{
    public class CheapPaymentGatewayProvider : IPaymentProcessorProvider
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        public CheapPaymentGatewayProvider(ICheapPaymentGateway cheapPaymentGateway)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
        }

        string IServiceBase.GatewayName => "Cheap Payment Gateway";

        decimal IServiceBase.MinAmount => 0.01m;

        decimal IServiceBase.MaxAmount => 21.00m;

        bool IServiceBase.isAvailable => true;

        public async Task<bool> ProcessPayment(PaymentRequest paymentRequest)
        {
            var result = await _cheapPaymentGateway.ProcessPayment(paymentRequest);
            return result;
        }
    }
}
