using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BulbasaurAPI.DTOs.Document;

namespace BulbasaurAPI.Models
{
    public class Document
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        public string FolderPath { get; set; }

        [MaxLength(255)]
        public string FileName { get; set; }

        public Guid DocumentGuid { get; set; }

        [MaxLength(255)]
        public string DocumentTitle { get; set; }

        public List<User> EligibleList { get; set; } = new();
        public List<Group> EligibleGroups { get; set; } = new();
        public User UploadedBy { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;

        [NotMapped]
        public string FilePath => Path.Combine(FolderPath, DocumentGuid.ToString());

        public Document()
        {
        }

        public Document(IncomingDocumentDTO incomingDocument, string folderPath, List<User> eligibleList, List<Group> eligibleGroups, User uploadedBy, Guid documentGuid)
        {
            FileName = incomingDocument.DocumentFileName;
            DocumentTitle = incomingDocument.DocumentTitle;

            FolderPath = folderPath;
            EligibleList = eligibleList;
            EligibleGroups = eligibleGroups;
            UploadedBy = uploadedBy;

            DocumentGuid = documentGuid;
        }
    }
}