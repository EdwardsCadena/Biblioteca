using Biblioteca.Data;
using Biblioteca.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using AutoMapper;
using Biblioteca.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet("by-author/{authorId}")]
        public async Task<IActionResult> GetBooksByAuthorId(int authorId)
        {
            try
            {
                var books = await _bookRepository.GetBooksByAuthorIdAsync(authorId);

                // Mapear los datos a DTOs usando AutoMapper
                var bookDtos = _mapper.Map<List<BookDto>>(books);

                return Ok(bookDtos);
            }
            catch (Exception ex)
            {
                // Puedes registrar el error aquí
                return StatusCode(500, new { Message = "Ocurrió un error al procesar la solicitud.", Details = ex.Message });
            }
        }
    }
}
