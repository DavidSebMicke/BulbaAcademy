using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Chat
{
    public class NewChatDTO
    {
        [Required(ErrorMessage = "Chatten måste innehålla användare.")]
        [MinLength(1, ErrorMessage = "Chatten måste innehålla användare.")]
        public List<int> Users { get; set; }

        [MaxLength(10000, ErrorMessage = "Chattmeddelandet är för långt.")]
        [MinLength(1, ErrorMessage = "Chattmeddelandet kan inte vara tomt.")]
        [Required(ErrorMessage = "Chatten måste påbörjas med ett meddelande.")]
        public string Message { get; set; }
    }
}