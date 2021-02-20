using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentTestApiTest.ValidatePaymentTest
{
    [NUnit.Framework.TestFixture]
    public class ValidatePaymentTest
    {
        private PaymentTestApi.ApplicationService.ValidatePaymentRequest.ValidatePaymentRequest _validatePaymentService;
        private Moq.Mock<IServiceProvider> _serviceProvider;
        private PaymentTestApi.Models.PaymentRequest _paymentRequest;

        [NUnit.Framework.SetUp]
        public void Setup()
        {
            _serviceProvider = new Moq.Mock<IServiceProvider>();
            _validatePaymentService = new PaymentTestApi.ApplicationService.ValidatePaymentRequest.ValidatePaymentRequest(_serviceProvider.Object);

            _paymentRequest = new PaymentTestApi.Models.PaymentRequest()
            {
                Amount = 500m,
                CardHolder = "",
                CreditCardNumber = "4187451853709443",
                ExpirationDate = DateTime.Now.AddMonths(-2),
                SecurityCode = ""
            };
        }

        [NUnit.Framework.Test]
        public void Validate_ExpiryDate_Not_In_Future_ReturnsFalse()
        {
            var result = _validatePaymentService.ValidateDate(_paymentRequest.ExpirationDate);

            NUnit.Framework.Assert.That(result, NUnit.Framework.Is.False);

        }
        
        [NUnit.Framework.Test]
        public void Validate_validateCreditCardNumber_IsValidCreditCardNumber_ReturnsTrue()
        {
            
            var result = _validatePaymentService.validateCreditCardNumber(_paymentRequest.CreditCardNumber);

            NUnit.Framework.Assert.That(result, NUnit.Framework.Is.EqualTo(true));

        }

    }
}
