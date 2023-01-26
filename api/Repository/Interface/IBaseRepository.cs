using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T entity);

        Task<T> Update(T newEntity);

        Task Delete(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<T?> GetById(int id);

        Task<bool> EntityExists(int id);
    }
}