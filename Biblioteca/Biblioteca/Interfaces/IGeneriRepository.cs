using Biblioteca.Data;
using Biblioteca.DTOs;
using System.Linq.Expressions;

namespace Biblioteca.Interfaces
{
    public interface IGeneriRepository<TEntity> where TEntity : class
    {
        Task <List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<List<Book>> GetAllBooksAsync();

    }
}
