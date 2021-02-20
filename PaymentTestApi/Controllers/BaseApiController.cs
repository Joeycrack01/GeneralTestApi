using MediSmartTestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediSmartTestApi.Controllers
{
    public class BaseApiController : Controller
    {

        [ApiExplorerSettings(IgnoreApi = true)]
        public void LogError(Exception ex)
        {
            try
            {
                Error _error = new Error()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateCreated = DateTime.Now
                };

                // implement error logging here
            }
            catch { }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string Error()
        {
            return "Oops! we encountered some difficulties. please contact us at support@expressgrocrey.com";
        }
    }
}
