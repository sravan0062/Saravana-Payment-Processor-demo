using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProcessPaymentDemo.Models
{
    public class PaymentDetails
    {

        [Required]
        public String CreditCardNumber = null;
        [Required]
        public String CardHolder = null;
        [Required]
        // public DateTime? ExpirationDate = null;
        public String ExpirationDate = null;

        [Range(0, 999)]
        public String SecurityCode = null;

        [Required]
        [Range(0, 9999999.999)]
        // public double Amount = 0D;
        public String Amount = null;



        // for logging
        public override string ToString()
        {
            return "CreditCardNumber:"+ CreditCardNumber+ ",CardHolder:"+ CardHolder+ ",ExpirationDate:"+ ExpirationDate+ ",SecurityCode:"+ SecurityCode+ ",Amount:"+ Amount;
        }


    }
}