using ProcessPaymentDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProcessPaymentDemo.Controllers
{

    public class PaymentsController : ApiController
    {


        [HttpGet]
        public String Stage1()
        {
            // Do something with the string here


            return "Its working Appa";
        }



        [HttpPost]
        public HttpResponseMessage ProcessPaymentJSONAppVersion1([FromBody] PaymentDetails paymentDetailsVO)
        {


            //     for validation    --> if (ModelState.IsValid)  | Filters


            System.Diagnostics.Debug.WriteLine("####In ProcessPaymentJSONAppVersion1##" + paymentDetailsVO);


            bool validDataPosted = ValidatePayment.IsValidPaymentDataPosted(paymentDetailsVO);

            // Validation failed
            if (!validDataPosted)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            System.Diagnostics.Debug.WriteLine("####In ProcessPaymentJSONAppVersion1## Validation Passed " );

            //
            PaymentGatewayProcessor paymentProcessor = new PaymentGatewayProcessor();
            String transaction_result = paymentProcessor.ProcessPayment(paymentDetailsVO);


            System.Diagnostics.Debug.WriteLine("####In ProcessPaymentJSONAppVersion1## transaction_result"+ transaction_result);

            if (transaction_result.Equals(TransactionResult.TRANSACTION_SUCCESS))
            {
                System.Diagnostics.Debug.WriteLine("####Transaction Successful##"+ paymentDetailsVO);
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            // for all other cases
            return Request.CreateResponse(HttpStatusCode.InternalServerError);


        }



    }
}

