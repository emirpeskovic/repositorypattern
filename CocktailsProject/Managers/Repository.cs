using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CocktailsProject.Managers;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;
    
    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public T? Get(int id) => _dbSet.Find(id);

    public IEnumerable<T> GetAll() => _dbSet.AsEnumerable();
    
    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);
}