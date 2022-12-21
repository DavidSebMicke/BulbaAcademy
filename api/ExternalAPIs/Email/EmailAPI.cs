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

            EmailContent emailContent = new(senderEmail, userEmail, "Login verification", "code");

            StringContent content = new(JsonSerializer.Serialize(emailContent).ToString(), Encoding.UTF8, "application/json");

            Console.WriteLine("STRING CONTENT \n " + content);
            Console.WriteLine();
            Console.WriteLine();
            var response = await client.PostAsync(uri, content);

            Console.WriteLine(response);

            return true;
        }
    }
}