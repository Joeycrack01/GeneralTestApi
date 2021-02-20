using PaymentTestApi.Base;
using PaymentTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.ProcessPaymentProvider
{
    public interface IPaymentProcessorProvider : IServiceBase
    {
        Task<bool> ProcessPayment(PaymentRequest paymentRequest);
    }
}
