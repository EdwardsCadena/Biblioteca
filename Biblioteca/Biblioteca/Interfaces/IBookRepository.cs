using Biblioteca.DTOs;

namespace Biblioteca.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BookDto>> GetBooksByAuthorIdAsync(int authorId);
    }
}
