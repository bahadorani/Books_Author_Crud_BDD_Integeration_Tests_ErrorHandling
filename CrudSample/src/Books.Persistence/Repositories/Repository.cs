using Books.Repository;
using Persistence;
using System.Linq.Expressions;
using Books.Persistence.Repositories.Exceptions;

namespace Books.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ProjectContext _context;

        public Repository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Get(int id)
        {
            var result = await _context.Set<TEntity>().FindAsync(id);

            if (result is null)
                throw new FailedToFindEntityByIdException("The entity was not found.", id.ToString());
           
            return result;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var result = _context.Set<TEntity>().SingleOrDefault(predicate);

            if (result == null)
                throw new FailedToFindEntityException();
            else
                return result;

        }

        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
           await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}