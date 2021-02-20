using PaymentTestApi.Models;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.ProcessPayment
{
    public interface IProcessPaymentService
    {
        Task<bool> ProcessPayment(PaymentRequest paymentRequest, string paymentGateway);
    }
}