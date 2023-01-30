using System.Text.Json.Serialization;

namespace BulbasaurAPI.ExternalAPIs.Email
{
    public class EmailContent
    {
        [JsonPropertyName("sender")]
        public EmailInfo sender { get; set; }

        [JsonPropertyName("to")]
        public EmailInfo[] to { get; set; }

        [JsonPropertyName("subject")]
        public string subject { get; set; }

        private string code = "";
        private string innerMsg = "";

        public EmailContent(string senderEmail, string receiverEmail, string subject, string code)
        {
            sender = new EmailInfo { email = senderEmail };
            to = new EmailInfo[1];
            to[0] = new EmailInfo { email = receiverEmail };
            this.subject = subject;
            this.code = code;
            this.innerMsg = innerMsg;
        }

        public EmailContent(EmailInfo sender, EmailInfo receiver, string subject, string code, string innerMsg)
        {
            this.sender = sender;
            to = new EmailInfo[1];
            to[0] = receiver;
            this.subject = subject;
            this.code = code;
        }

        [JsonPropertyName("htmlContent")]
        public string htmlContent
        {
            get
            {
                return $"<html><head></head><body><h2>{innerMsg}</h2><p>{code}</p></body></html>"; ;
            }
        }
    }
}