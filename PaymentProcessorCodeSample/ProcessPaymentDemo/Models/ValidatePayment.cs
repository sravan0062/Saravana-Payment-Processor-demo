using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessPaymentDemo.Models
{
    public class ValidatePayment
    {
        private static bool IsLong(String input)
        {
            ulong result;
            return ulong.TryParse(input, out result);
        }
        private static bool IsValidAmount(String input)
        {
            double result;
            bool ans = double.TryParse(input, out result);
            return (ans && result > 0);

        }

        private static bool IsValidDate(String input)
        {
            DateTime result;
            return DateTime.TryParse(input, out result);
        }

        private static bool IsValidSecurityCode(String input)
        {
            if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            if (input.Trim().Length == 3)
            {
                ushort result;
                return ushort.TryParse(input, out result);
            }

            return false;
        }

        private static bool IsValidCardHolder(String name)
        {

            if (String.IsNullOrEmpty(name))
            {
                return false;
            }

            return true;
        }

        private static bool ValidateString(params string[] values)
        {
            foreach (string strin in values)
            {
                if (String.IsNullOrEmpty(strin) || String.IsNullOrWhiteSpace(strin))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidPaymentDataPosted(PaymentDetails paymentDetailVO)
        {

            if (ValidateString(paymentDetailVO.CreditCardNumber, paymentDetailVO.CardHolder, paymentDetailVO.Amount, paymentDetailVO.ExpirationDate))

            {



                if (IsValidCardNumber(paymentDetailVO.CreditCardNumber) &&
                 IsValidCardHolder(paymentDetailVO.CardHolder) &&
                 IsValidAmount(paymentDetailVO.Amount) &&
                 IsValidDate(paymentDetailVO.ExpirationDate) &&
                 IsValidSecurityCode(paymentDetailVO.SecurityCode))
                {

                    return true;

                }


            }



            return false;

        }



        private static bool IsValidCardNumber(string cardNumber)
        {

            if (IsLong(cardNumber) && cardNumber.Length == 16)
            {

                return true;

            }
            return false;
        }
    }
}