using System.Text.Json.Serialization;

namespace BulbasaurAPI.ExternalAPIs.Recaptcha
{
    public class RecaptchaVerificationModel
    {
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        [JsonPropertyName("response")]
        public string Response { get; set; }

        [JsonPropertyName("remoteip")]
        public string? RemoteIP { get; set; }
    }
}