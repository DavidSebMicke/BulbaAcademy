using BulbasaurAPI.Database;
using BulbasaurAPI.DTOs.Chat;
using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;

namespace BulbasaurAPI.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly DbServerContext _context;

        public ChatRepository(DbServerContext context)
        {
            _context = context;
        }

        public async Task<Chat?> Get(int chatId)
        {
            return await _context.Chats
            .Include(c => c.InvolvedUsersList)
            .ThenInclude(u => u.Person)
            .ThenInclude(p => p.Role)
            .Include(c => c.ChatItemList)
            .ThenInclude(ci => ci.Author)
            .FirstAsync(c => c.Id == chatId);
        }

        public async Task<Chat?> Get(int chatId, User user)
        {
            return await _context.Chats.Include(c => c.ChatItemList).FirstAsync(c => c.Id == chatId && c.InvolvedUsersList.Any(u => u.Id == user.Id));
        }

        public async Task<ICollection<Chat>?> GetChats(User user)
        {
            return await _context.Chats
                        .Include(c => c.InvolvedUsersList)
                        .ThenInclude(u => u.Person)
                        .ThenInclude(p => p.Role)
                        .Include(c => c.ChatItemList)
                        .Where(c => c.InvolvedUsersList.Contains(user))
                        .ToListAsync();
        }

        public async Task<Chat?> CreateChat(Chat chat)
        {
            var dbChat = (await _context.Chats.AddAsync(chat)).Entity;
            return dbChat;
        }

        public async Task<Chat?> UpdateChat(Chat chat)
        {
            var updatedChat = _context.Chats.Update(chat).Entity;
            return updatedChat;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<ChatItem> CreateChatItem(ChatItem chatItem)
        {
            var dbItem = (await _context.ChatItems.AddAsync(chatItem)).Entity;
            return dbItem;
        }

        // Get users from int list
        public async Task<List<User>> GetUsersByIds(List<int> ids)
        {
            return await _context.Users.Where(u => ids.Any(i => i == u.Id)).ToListAsync();
        }
    }
}