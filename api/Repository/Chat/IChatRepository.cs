using BulbasaurAPI.DTOs.Chat;
using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository.Chat
{
    public interface IChatRepository
    {
        Task<ChatDTO?> Get(User user, int chatId);

        Task<ChatDTO?> CreateChat(User user, NewChatDTO newChat);

        Task<ChatDTO?> SendMessage(User user, ChatMessageDTO newMessage);

        Task<ICollection<ChatInfoDTO>?> GetChats(User user);
    }
}