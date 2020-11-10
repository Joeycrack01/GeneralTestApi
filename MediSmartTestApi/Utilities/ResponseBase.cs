using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediSmartTestApi.Utilities
{
    public class ResponseBase<T> : ResponseBase
    {
        public T Payload
        {
            get;
            set;
        }
    }

    public class ResponseBase
    {
        public bool IsAPI
        {
            get
            {
                return true;
            }
        }

        public string ErrorDetails
        {
            get;
            set;
        }

        public bool IsSuccess
        {
            get;
            set;
        }

        public bool IsUpdate
        {
            get;
            set;
        }

    }
}
