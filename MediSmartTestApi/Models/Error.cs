using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediSmartTestApi.Models
{
    public class Error
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
