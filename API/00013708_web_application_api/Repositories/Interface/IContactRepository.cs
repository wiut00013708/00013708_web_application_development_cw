using _00013708_web_application_api.Models.Domain;

namespace _00013708_web_application_api.Repositories.Interface
{
    public interface IContactRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIDAsync(int id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
