using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DbServerContext _context;

        public DocumentRepository(DbServerContext context)
        {
            _context = context;
        }

        public async Task<Document> Create(Document entity)
        {
            return (await _context.Documents.AddAsync(entity)).Entity;
        }

        public async Task<Document> Update(Document newEntity)
        {
            var savedDocument = _context.Documents.Update(newEntity).Entity;
            await _context.SaveChangesAsync();
            return savedDocument;
        }

        public async Task Delete(Document entity)
        {
            _context.Documents.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Document>> GetAll()
        {
            return await _context.Documents
                .Include(d => d.UploadedBy)
                .Include(d => d.EligibleList)
                .Include(d => d.EligibleGroups).ThenInclude(g => g.People)
                .ToListAsync();
        }

        public async Task<Document?> GetById(int id)
        {
            return await _context.Documents.Include(d => d.UploadedBy).FirstAsync(d => d.Id == id);
        }

        public async Task<bool> EntityExists(int id)
        {
            return await _context.Documents.AnyAsync(doc => doc.Id == id);
        }

        public async Task<List<User>> GetUsersById(List<int> ids)
        {
            return await _context.Users.Where(u => ids.Contains(u.Id)).ToListAsync();
        }

        public async Task<List<Group>> GetGroupsById(List<int> ids)
        {
            return await _context.Groups.Where(g => ids.Contains((g.Id))).ToListAsync();
        }
    }
}