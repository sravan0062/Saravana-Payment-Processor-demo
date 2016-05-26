using ProcessPaymentDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessPaymentDemo.Providers
{
    public class IExpensivePaymentGatewayProvider : _IPaymentGatewayProvider
    {

        public String ProcessPayment(PaymentDetails paymentdetailVO)
        {

            return TransactionResult.TRANSACTION_SUCCESS;
        }

    
    }
}