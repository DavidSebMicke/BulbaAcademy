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
            .Include(c => c.ChatItemList)
            .AsNoTracking()
            .FirstAsync(c => c.Id == chatId);
        }

        public async Task<ICollection<Chat>?> GetChats(User user)
        {
            return await _context.Chats
                        .Include(c => c.InvolvedUsersList)
                        .ThenInclude(u => u.Person)
                        .Include(c => c.ChatItemList)
                        .Where(c => c.InvolvedUsersList.Contains(user))
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<Chat?> CreateChat(Chat chat)
        {
            var dbChat = (await _context.Chats.AddAsync(chat)).Entity;
            await _context.SaveChangesAsync();

            return dbChat;
        }

        public async Task<Chat?> UpdateChat(Chat chat)
        {
            var updatedChat = _context.Chats.Update(chat).Entity;
            await _context.SaveChangesAsync();
            return updatedChat;
        }

        // Get users from int list
        public async Task<List<User>> GetUsersByIds(List<int> ids)
        {
            return await _context.Users.Where(u => ids.Contains(u.Id)).ToListAsync();
        }
    }
}