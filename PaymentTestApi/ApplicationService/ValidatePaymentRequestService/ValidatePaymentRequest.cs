using Microsoft.Extensions.DependencyInjection;
using PaymentTestApi.ApplicationService.ProcessPaymentProvider;
using PaymentTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.ValidatePaymentRequest
{
    public class ValidatePaymentRequest : IValidatePaymentRequest
    {
        private readonly IServiceProvider _serviceProvider;
        public ValidatePaymentRequest(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> ValidatePayment(PaymentRequest paymentRequest)
        {
            if (paymentRequest.Amount < 0) return false;


            if (!ValidateDate(paymentRequest.ExpirationDate)) return false;

            //if security No is Not null validate that its 3 digit
            if (!string.IsNullOrEmpty(paymentRequest.SecurityCode))
            {
                if (!int.TryParse(paymentRequest.SecurityCode, out int secCode)) return false;
            }

            // check credit card validity
            if (!validateCreditCardNumber(paymentRequest.CreditCardNumber)) return false;

            var paymentGatewayService = new List<IPaymentProcessorProvider>();
            using (var scope = _serviceProvider.CreateScope())
            {
                paymentGatewayService = scope.ServiceProvider.GetRequiredService<IEnumerable<IPaymentProcessorProvider>>().ToList();
            }

            var paymentGateway = paymentGatewayService.Where(r => paymentRequest.Amount >= r.MinAmount && paymentRequest.Amount <= r.MaxAmount && r.isAvailable == true).FirstOrDefault();

            var result = await paymentGateway.ProcessPayment(paymentRequest);

            return result;

        }

        public bool ValidateDate (DateTime ExpirationDate)
        {
            if (ExpirationDate.Date < DateTime.Now.Date) return false;

            return true;
        }

        public bool validateCreditCardNumber(string creditCardNumber)
        {
            //// check whether input string is null or empty
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                return false;
            }

            //// 1.	Starting with the check digit double the value of every other digit 
            //// 2.	If doubling of a number results in a two digits number, add up
            ///   the digits to get a single digit number. This will results in eight single digit numbers                    
            //// 3. Get the sum of the digits
            int sumOfDigits = creditCardNumber.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);


            //// If the final sum is divisible by 10, then the credit card number
            //   is valid. If it is not divisible by 10, the number is invalid.            
            return sumOfDigits % 10 == 0;
        }

    }
}
