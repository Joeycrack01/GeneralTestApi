using PaymentTestApi.Models;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.PremiumPaymentService
{
    public interface IPremiumPaymentGateway
    {
        Task<bool> ProcessPayment(PaymentRequest paymentRequest);
    }
}