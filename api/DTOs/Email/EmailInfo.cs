using System.Text.Json.Serialization;

namespace BulbasaurAPI.ExternalAPIs.Email
{
    public class EmailInfo
    {
        [JsonPropertyName("name")]
        public string? name { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }
    }
}