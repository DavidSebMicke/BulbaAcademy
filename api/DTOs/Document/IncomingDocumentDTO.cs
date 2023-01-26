using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Document
{
    public class IncomingDocumentDTO
    {
        public byte[] Document { get; set; }

        [MaxLength(255)]
        public string DocumentFileName { get; set; }

        [MaxLength(255)]
        public string DocumentTitle { get; set; }

        public List<int>? EligibleUserIds { get; set; }
        public List<int>? EligibleGroupIds { get; set; }
    }
}