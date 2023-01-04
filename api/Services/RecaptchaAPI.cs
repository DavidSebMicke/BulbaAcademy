using dotenv.net;
using System.Text.Json;

namespace BulbasaurAPI.ExternalAPIs.Recaptcha
{
    public class RecaptchaAPI
    {
        internal static async Task<bool> VerifyRecaptcha(string userToken, string? userIP)
        {
            HttpClient client = new HttpClient();

            string recaptchaSecret = DotEnv.Read()["RECAPTCHA_SECRET"];

            RecaptchaVerificationModel model = new RecaptchaVerificationModel { Secret = recaptchaSecret, Response = userToken, RemoteIP = userIP };

            try
            {
                var response = await client.PostAsJsonAsync("https://www.google.com/recaptcha/api/siteverify", model);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    RecaptchaResponse? responseContent = JsonSerializer.Deserialize<RecaptchaResponse>(json);

                    if (responseContent != null && responseContent.Success == true) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in RecaptchaAPI call:\n" + ex.Message);
                return false;
            }
        }
    }
}