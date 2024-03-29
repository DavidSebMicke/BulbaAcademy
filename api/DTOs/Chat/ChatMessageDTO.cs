﻿using BulbasaurAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Chat
{
    public class ChatMessageDTO
    {
        [Required(ErrorMessage = "ChattId saknas.")]
        public int ChatId { get; set; }

        public ChatUserDTO? Sender { get; set; }

        [MaxLength(10000, ErrorMessage = "Chattmeddelandet är för långt.")]
        [Required(ErrorMessage = "Chattmeddelanden kan inte vara tomma.")]
        public string Message { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public ChatMessageDTO()
        {
        }

        public ChatMessageDTO(ChatItem chatItem)
        {
            Sender = new ChatUserDTO(chatItem.Author);
            Message = chatItem.Message;
            Timestamp = chatItem.DateTime;
        }
    }
}