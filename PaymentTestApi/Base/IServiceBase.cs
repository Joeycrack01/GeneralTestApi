using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentTestApi.Base
{
    public interface IServiceBase
    {
        string GatewayName { get;}
        decimal MinAmount { get;}
        decimal MaxAmount { get;}
        bool isAvailable { get;}
    }
}
