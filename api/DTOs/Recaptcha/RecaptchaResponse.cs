using System.Text.Json.Serialization;

namespace BulbasaurAPI.ExternalAPIs.Recaptcha
{
    public class RecaptchaResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("challenge_ts")]
        public DateTime ChallengeTimeStamp { get; set; }

        [JsonPropertyName("hostname")]
        public string HostName { get; set; }

        [JsonPropertyName("error-codes")]
        public Array? ErrorCodes { get; set; }
    }
}