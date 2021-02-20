using PaymentTestApi.ApplicationService.ProcessPaymentProvider;
using PaymentTestApi.Base;
using PaymentTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.PremiumPaymentService
{
    public class PremiumPaymentGatewayProvider : IPaymentProcessorProvider
    {
        private readonly IPremiumPaymentGateway _premiumPaymentGateway;
        public PremiumPaymentGatewayProvider(IPremiumPaymentGateway premiumPaymentGateway)
        {
            _premiumPaymentGateway = premiumPaymentGateway;
        }

        string IServiceBase.GatewayName => "Premium Payment Gateway";

        decimal IServiceBase.MinAmount => 500.00m;

        decimal IServiceBase.MaxAmount => decimal.MaxValue;

        bool IServiceBase.isAvailable => true;

        public async Task<bool> ProcessPayment(PaymentRequest paymentRequest)
        {
            var result = await _premiumPaymentGateway.ProcessPayment(paymentRequest);
            return result;
        }
    }
}
