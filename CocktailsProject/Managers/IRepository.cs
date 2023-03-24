using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CocktailsProject.Managers;

public interface IRepository<T> where T : class
{
    public void Add(T entity);
    public void Remove(T entity);
    public void Update(T entity);
    public T? Get(int id);
    public IEnumerable<T> GetAll();
    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
}