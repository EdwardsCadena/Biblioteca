using Biblioteca.Data;
using Biblioteca.DTOs;
using Biblioteca.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repository
{
    public class GeneriRepository<TEntity> : IGeneriRepository<TEntity> where TEntity : class
    {
        private readonly BibliotecaContext _context;

        public GeneriRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books
                        .Include(b => b.Author)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity is Book book)
            {
                var existingBook = await _context.Set<Book>()
                    .Include(b => b.Author)
                    .FirstOrDefaultAsync(b => b.Id == book.Id);

                if (existingBook != null)
                {
                    _context.Entry(existingBook).CurrentValues.SetValues(book);

                    if (book.Author != null)
                    {
                        var existingAuthor = await _context.Authors.FindAsync(book.Author.Id);
                        if (existingAuthor != null)
                        {
                            _context.Entry(existingAuthor).CurrentValues.SetValues(book.Author);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

    }
}
