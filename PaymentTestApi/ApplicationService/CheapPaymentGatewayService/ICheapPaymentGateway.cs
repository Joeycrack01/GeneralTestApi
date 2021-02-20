using PaymentTestApi.Models;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService
{
    public interface ICheapPaymentGateway
    {
        Task<bool> ProcessPayment(PaymentRequest paymentRequest);
    }
}