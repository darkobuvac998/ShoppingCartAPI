using System.Linq.Expressions;

namespace ShoppingCart.Contracts.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        ICollection<T> FindAll(bool trackChanges);
        ICollection<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<ICollection<T>> FindAllAsync(bool trackChanges);
        Task<ICollection<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
