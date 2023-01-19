namespace BulbasaurAPI.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<bool> Update();
        Task<bool> Delete(T entity);
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task<bool> SaveAsync();
        T EntityExists(int id);

    }
}
