using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SKY
{
    public static class TwilioAPI
    {
        static string accountSid = "ACb07f51e7119295dc213b4b7f51a4ac2b";
        static string authToken = "40ea07cf82607ee3691ff548039407ce";

        public static void SendSMS(string to, string text)
        {
            TwilioClient.Init(accountSid, authToken);

            //var from = new PhoneNumber("+12014743287");
            var from = "Sky Electronics";
            var newTo = new PhoneNumber("+" + to);

            var message = MessageResource.Create(
                to: newTo,
                from: from,
                body: text);
        }
    }
}