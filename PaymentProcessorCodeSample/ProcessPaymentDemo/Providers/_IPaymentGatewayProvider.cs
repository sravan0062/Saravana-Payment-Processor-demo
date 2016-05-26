using ProcessPaymentDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessPaymentDemo.Providers
{
     interface _IPaymentGatewayProvider
    {

         String ProcessPayment(PaymentDetails paymentdetailVO);
        
    }
}
