using Microsoft.EntityFrameworkCore;
using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Entities.Data;
using System.Linq.Expressions;

namespace ShoppingCart.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ShoppingCartDatabaseContext dbContext;

        public BaseRepository(ShoppingCartDatabaseContext context)
        {
            dbContext = context;
        }

        public void Create(T entity) => dbContext.Set<T>().Add(entity);

        public async Task CreateAsync(T entity) => await dbContext.Set<T>().AddAsync(entity);

        public void Delete(T entity) => dbContext.Set<T>().Remove(entity);

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> FindAll(bool trackChanges) => trackChanges ? dbContext.Set<T>().ToList() : dbContext.Set<T>().AsNoTracking().ToList();

        public async Task<ICollection<T>> FindAllAsync(bool trackChanges) => 
            trackChanges ? await dbContext.Set<T>().ToListAsync() 
            : await dbContext.Set<T>().AsNoTracking().ToListAsync();

        public ICollection<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => 
            trackChanges ? dbContext.Set<T>().Where(expression).ToList() 
            : dbContext.Set<T>().Where(expression).AsNoTracking().ToList();

        public async Task<ICollection<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges) =>
            trackChanges ? await dbContext.Set<T>().Where(expression).ToListAsync()
            : await dbContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();

        public void Update(T entity) => dbContext.Update(entity);

    }
}
