
using AutoMapper;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetails;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;
using static WebApi.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static WebApi.Application.AuthorOperations.Queries.GetAuthors.GetAuthorsQuery;
using static WebApi.Application.BookOperations.Queries.GetBookDetails.GetBookByIdQuery;
using static WebApi.Application.BookOperations.Queries.GetBooks.GetBooksQuery;
using static WebApi.Application.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQuery;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookVM, Book>();
            //CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BookDetailVM>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                                           .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname));

            CreateMap<Book, BooksVM>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                                            .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname))
                                            .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.PublishedDate.Date.ToString("dd/MM/yyy")));

            CreateMap<Genre, GenreVM>();
            CreateMap<Genre, GenreDetailVM>();

            CreateMap<Author, AuthorVM>().ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date.ToString("dd/MM/yyy")));

            CreateMap<Author, AuthorDetailVM>().ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date.ToString("dd/MM/yyy")));

            CreateMap<CreateAuthorVM, Author>();

        }
    }
}