using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTestApi.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string paymentStatus { get; set; }
        public string paymentGateWay { get; set; }
        public DateTime paymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public int Otp { get; set; }

    }
}
