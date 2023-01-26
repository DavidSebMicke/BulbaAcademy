using BulbasaurAPI.DTOs.Chat;
using BulbasaurAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;

namespace BulbasaurAPI.Repository.Chat
{
    public class ChatRepository : IChatRepository
    {
        private readonly DbServerContext _context;

        public ChatRepository(DbServerContext context)
        {
            _context = context;
        }

        public async Task<ChatDTO?> Get(User user, int chatId)
        {
            try
            {
                var chat = await _context.Chats
                            .Include(c => c.InvolvedUsersList)
                            .ThenInclude(u => u.Person)
                            .Include(c => c.ChatItemList)
                            .AsNoTracking()
                            .FirstAsync(c => c.Id == chatId);

                // Might need to switch this out to something else
                if (CheckUserInChat(user, chat))
                {
                    return new ChatDTO(chat);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ChatDTO?> CreateChat(User user, NewChatDTO newChat)
        {
            try
            {
                var users = await _context.Users.Where(u => newChat.Users.Any(nu => nu.Id == u.Id)).ToListAsync();
                users.Add(user);

                var chatItems = new List<ChatItem>()
                {
                    new ChatItem() { Author = user, Message = newChat.Message }
                };

                var chat = new Models.Chat() { InvolvedUsersList = users, ChatItemList = chatItems };

                var dbChat = await _context.Chats.AddAsync(chat);
                await _context.SaveChangesAsync();

                return new ChatDTO(chat);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ICollection<ChatInfoDTO>?> GetChats(User user)
        {
            try
            {
                var chats = await _context.Chats
                            .Include(c => c.InvolvedUsersList)
                            .ThenInclude(u => u.Person)
                            .Include(c => c.ChatItemList)
                            .Where(c => c.InvolvedUsersList.Contains(user))
                            .AsNoTracking()
                            .ToListAsync();
                // Might need a second user check, but the Where should take care of that

                var chatInfoDTOs = (ICollection<ChatInfoDTO>)chats.Select(chat => new ChatInfoDTO(chat)).ToList();

                return chatInfoDTOs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ChatDTO?> SendMessage(User user, ChatMessageDTO newMessage)
        {
            try
            {
                var chat = await _context.Chats
                    .Include(c => c.ChatItemList)
                    .Include(c => c.ChatItemList)
                    .FirstAsync(c => c.Id == newMessage.ChatId);

                if (chat == null) return null;

                if (CheckUserInChat(user, chat))
                {
                    var chatItem = new ChatItem()
                    {
                        Author = user,
                        Message = newMessage.Content
                    };
                    chat.ChatItemList.Add(chatItem);

                    await _context.SaveChangesAsync();

                    return new ChatDTO(chat);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Utility methods for checking if a user is involved in a chat
        private bool CheckUserInChat(User user, Models.Chat chat)
        {
            return chat.InvolvedUsersList.Contains(user);
        }
    }
}