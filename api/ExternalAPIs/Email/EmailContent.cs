namespace BulbasaurAPI.ExternalAPIs.Email
{
    public class EmailContent
    {
        internal EmailInfo sender { get; set; }
        internal EmailInfo[] to { get; set; }
        internal string subject { get; set; }
        private string code = "";

        public EmailContent(string senderEmail, string receiverEmail, string subject, string code)
        {
            sender = new EmailInfo { email = senderEmail };
            to = new EmailInfo[1];
            to[0] = new EmailInfo { email = receiverEmail };
            this.subject = subject;
            this.code = code;
        }

        internal string htmlContent
        {
            get
            {
                return $"<html><head></head><body><h2>Your secret code:</h2><p>{code}</p></body></html>"; ;
            }
        }
    }
}