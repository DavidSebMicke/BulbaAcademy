using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Document
{
    public class IncomingDocumentDTO
    {
        [Required(ErrorMessage = "Dokumentet saknas.")]
        [MinLength(1, ErrorMessage = "Dokumentet är tomt.")]
        public byte[] Document { get; set; }

        [MaxLength(255, ErrorMessage = "Filnamnet är för långt.")]
        [MinLength(1, ErrorMessage = "Filnamnet är tomt.")]
        [Required(ErrorMessage = "Filnamnet saknas.")]
        public string DocumentFileName { get; set; }

        [MaxLength(255, ErrorMessage = "Dokumentets titel är för långt.")]
        [Required(ErrorMessage = "Dokumentet behöver en beskrivande titel.")]
        [MinLength(1, ErrorMessage = "Dokumentets titel är tom.")]
        public string DocumentTitle { get; set; }

        public List<int>? EligibleUserIds { get; set; }
        public List<int>? EligibleGroupIds { get; set; }
    }
}