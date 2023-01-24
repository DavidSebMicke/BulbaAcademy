namespace BulbasaurAPI.DTOs.Document
{
    public class IncomingDocumentDTO
    {
        public byte[] Document { get; set; }
        public string DocumentFileName { get; set; }
        public string DocumentTitle { get; set; }
        public List<int>? EligibleUserIds { get; set; }
        public List<int>? EligibleGroupIds { get; set; }
    }
}