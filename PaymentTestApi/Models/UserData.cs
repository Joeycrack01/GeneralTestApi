using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediSmartTestApi.Models
{
    public class UserData
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; set; }
        public long Bvn { get; set; }
        public string StaffId { get; set; }
        public string Department { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string StateOfOrigin { get; set; }
    }
}
