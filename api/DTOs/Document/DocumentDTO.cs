using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Document
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public byte[] Document { get; set; }
        public DateTime UploadDate { get; set; }

        [MaxLength(255)]
        public string DocumentTitle { get; set; }

        // Exchange this for a PersonDTO later
        [MaxLength(200)]
        public string UploadedBy { get; set; }

        public DocumentDTO(Models.Document document, byte[] documentData)
        {
            Document = documentData;

            Id = document.Id;
            UploadDate = document.UploadDate;
            DocumentTitle = document.DocumentTitle;
            UploadedBy = $"{document.UploadedBy.Person.FirstName} {document.UploadedBy.Person.LastName}";
        }
    }
}