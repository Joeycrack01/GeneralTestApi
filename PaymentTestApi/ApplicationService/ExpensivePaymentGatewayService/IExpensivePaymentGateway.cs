using PaymentTestApi.Models;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.ExpensivePaymentGatewayService
{
    public interface IExpensivePaymentGateway
    {
        Task<bool> ProcessPayment(PaymentRequest paymentRequest);
    }
}