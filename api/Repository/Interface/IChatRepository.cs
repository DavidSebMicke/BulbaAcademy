using BulbasaurAPI.DTOs.Chat;
using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository.Interface
{
    public interface IChatRepository
    {
        Task<Chat?> Get(int chatId);

        Task<ICollection<Chat>?> GetChats(User user);

        Task<Chat?> CreateChat(Chat chat);

        Task<ChatItem?> CreateChatItem(ChatItem chatItem);

        Task<Chat?> UpdateChat(Chat chat);

        Task<List<User>> GetUsersByIds(List<int> ids);

        Task SaveChangesAsync();
    }
}