using ProcessPaymentDemo.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProcessPaymentDemo.Models
{
    public class PaymentGatewayProcessor
    {

        _IPaymentGatewayProvider payment_gateway = null;
        public String ProcessPayment(PaymentDetails paymnetDetailsVO)
        {


            double amount_in_dbl;
            double.TryParse(paymnetDetailsVO.Amount, out amount_in_dbl);
            String transcation_result = null;


            if (amount_in_dbl < 20)
            {
                // process with ICheapPaymentGatewayProvider
                payment_gateway = new ICheapPaymentGatewayProvider();
                transcation_result = payment_gateway.ProcessPayment(paymnetDetailsVO);
                return transcation_result;

            }
            else if (amount_in_dbl > 20 && amount_in_dbl <= 500)
            {
                // process with IExpensivePaymentGatewayProvider
                payment_gateway = new IExpensivePaymentGatewayProvider();
                transcation_result = payment_gateway.ProcessPayment(paymnetDetailsVO);

                if (transcation_result.Equals(TransactionResult.TRANSACTION_FAIL))
                {
                    // Transaction failed try with the cheapPaymentprovider Once
                    payment_gateway = new ICheapPaymentGatewayProvider();
                    transcation_result = payment_gateway.ProcessPayment(paymnetDetailsVO);


                }

                return transcation_result;






            }
            else
            {
                // process with IPremiumPaymentGatewayProvider

                payment_gateway = new IPremiumPaymentGatewayProvider();
                transcation_result = payment_gateway.ProcessPayment(paymnetDetailsVO);
                // Try thrice
                for (int trial_attempts = 0; trial_attempts < 3; trial_attempts++)
                {
                    if (transcation_result.Equals(TransactionResult.TRANSACTION_SUCCESS))
                    {

                        break;
                    }

                }
                return transcation_result;
            }



        }


    }
}