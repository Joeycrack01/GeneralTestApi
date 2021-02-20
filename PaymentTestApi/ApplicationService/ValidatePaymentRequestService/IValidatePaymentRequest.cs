using PaymentTestApi.Models;
using System.Threading.Tasks;

namespace PaymentTestApi.ApplicationService.ValidatePaymentRequest
{
    public interface IValidatePaymentRequest
    {
        Task<bool> ValidatePayment(PaymentRequest paymentRequest);
    }
}