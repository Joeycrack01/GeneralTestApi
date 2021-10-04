﻿//using EasyRetry;
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
        //private readonly IEasyRetry _easyRetry;
        public PremiumPaymentGateway(IProcessPaymentService processPaymentService /*,IEasyRetry easyRetry*/)
        {
            _processPaymentService = processPaymentService;
            //_easyRetry = easyRetry;
        }

        public string GatewayName = "Premium Payment Gateway";

        public async Task<bool> ProcessPayment(PaymentRequest paymentRequest)
        {
            //var result = await _easyRetry.Retry(async () => await _processPaymentService.ProcessPayment(paymentRequest, GatewayName), new RetryOptions()
            //{
            //    Attempts = 3,
            //});

            //await new EasyRetry().Retry(async () => await _processPaymentService.ProcessPayment(paymentRequest, GatewayName);

            return false;

        }
    }
}
