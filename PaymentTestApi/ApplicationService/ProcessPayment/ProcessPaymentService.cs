using MediSmartTestApi.Utilities;
using PaymentTestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.ProcessPayment
{
    public class ProcessPaymentService : IProcessPaymentService
    {
        private readonly DataContext _context;
        public ProcessPaymentService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> ProcessPayment(PaymentRequest paymentRequest, string paymentGateway)
        {
            Payment payment = new Payment()
            {
                AmountPaid = paymentRequest.Amount,
                paymentDate = DateTime.Now,
                paymentGateWay = paymentGateway,
                paymentStatus = "Pending"
            };

            try
            {
                await _context.Payments.AddAsync(payment);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            


        }
    }
}
