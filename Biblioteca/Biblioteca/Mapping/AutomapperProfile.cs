using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using AutoMapper;
using Biblioteca.Data;
using Biblioteca.DTOs;

namespace Biblioteca.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();

        }
    }
}
