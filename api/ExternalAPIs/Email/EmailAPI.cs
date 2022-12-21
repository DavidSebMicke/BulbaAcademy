using BulbasaurAPI.ExternalAPIs.Email;
using dotenv.net;
using System.Text;
using System.Text.Json;

namespace BulbasaurAPI.ExternalAPIs
{
    internal class EmailAPI
    {
        internal static async Task<bool> Send2FAEmail(string userEmail)
        {
            HttpClient client = new HttpClient();

            string uri = "https://api.sendinblue.com/v3/smtp/email";
            string apiKey = DotEnv.Read()["MAIL_API_KEY"];
            string senderEmail = DotEnv.Read()["MAIL_SENDER_EMAIL"];

            client.DefaultRequestHeaders.Add("api-key", apiKey);

            EmailInfo sender = new EmailInfo { email = senderEmail, name = "Bulbasaur School" };
            EmailInfo receiver = new EmailInfo { email = userEmail, name = "ReceiverName" };

            EmailContent emailContent = new(sender, receiver, "Login verification", "code");

            StringContent content = new(JsonSerializer.Serialize(emailContent).ToString(), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);

            return true;
        }
    }
}