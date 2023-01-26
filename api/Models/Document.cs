using System.ComponentModel.DataAnnotations.Schema;
using BulbasaurAPI.DTOs.Document;

namespace BulbasaurAPI.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string FolderPath { get; set; }
        public string FileName { get; set; }
        public string DocumentTitle { get; set; }
        public List<User> EligibleList { get; set; }
        public List<Group> EligibleGroups { get; set; }
        public User UploadedBy { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;

        [NotMapped]
        public string FilePath => Path.Combine(FolderPath, FileName);

        public Document(IncomingDocumentDTO incomingDocument, string folderPath, List<User> eligibleList, List<Group> eligibleGroups, User uploadedBy)
        {
            FileName = incomingDocument.DocumentFileName;
            DocumentTitle = incomingDocument.DocumentTitle;

            FolderPath = folderPath;
            EligibleList = eligibleList;
            EligibleGroups = eligibleGroups;
            UploadedBy = uploadedBy;
        }
    }
}