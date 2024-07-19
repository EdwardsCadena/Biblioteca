using Biblioteca.Data;
using Biblioteca.DTOs;
using Biblioteca.Interfaces;
using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
    private readonly BibliotecaContext _context;

    public BookRepository(BibliotecaContext context)
    {
        _context = context;
    }

   
    public async Task<List<BookDto>> GetBooksByAuthorIdAsync(int authorId)
    {
        return await _context.Books
            .Where(b => b.Authorid == authorId)
            .Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = new AuthorDto
                {
                    Id = b.Author.Id,
                    Name = b.Author.Name
                }
            })
            .ToListAsync();
    }
}
