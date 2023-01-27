using BulbasaurAPI.ExternalAPIs.Email;
using dotenv.net;
using System.Text;
using System.Text.Json;

namespace BulbasaurAPI.ExternalAPIs
{
    internal class EmailAPI
    {
        internal static async Task<bool> SendPasswordToUserEmail(string email, string password)
        {
            HttpClient client = new HttpClient();

            string uri = "https://api.sendinblue.com/v3/smtp/email";
            string apiKey = DotEnv.Read()["MAIL_API_KEY"];
            string senderEmail = DotEnv.Read()["MAIL_SENDER_EMAIL"];

            client.DefaultRequestHeaders.Add("api-key", apiKey);

            EmailInfo sender = new EmailInfo { email = senderEmail, name = "Bulbasaur School" };
            EmailInfo receiver = new EmailInfo { email = email, name = "ReceiverName" };

            EmailContent emailContent = new(sender, receiver, "Here is your password to Bulba Academy!", password);

            var response = await client.PostAsJsonAsync(uri, emailContent);

            return response.IsSuccessStatusCode;
        }

        internal static async Task<bool> Send2FAEmail(string userEmail, string twoFactorCode)
        {
            HttpClient client = new HttpClient();

            string uri = "https://api.sendinblue.com/v3/smtp/email";
            string apiKey = DotEnv.Read()["MAIL_API_KEY"];
            string senderEmail = DotEnv.Read()["MAIL_SENDER_EMAIL"];

            client.DefaultRequestHeaders.Add("api-key", apiKey);

            EmailInfo sender = new EmailInfo { email = senderEmail, name = "Bulbasaur School" };
            EmailInfo receiver = new EmailInfo { email = userEmail, name = "ReceiverName" };

            EmailContent emailContent = new(sender, receiver, "Bulba Academy - Login with your two factor code!", twoFactorCode);

            var response = await client.PostAsJsonAsync(uri, emailContent);

            return response.IsSuccessStatusCode;
        }
    }
}