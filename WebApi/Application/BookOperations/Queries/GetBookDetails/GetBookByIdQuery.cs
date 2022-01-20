using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Queries.GetBookDetails
{
    public partial class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookByIdQuery(BookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public BookDetailVM Handle()
        {
            var book = _dbContext.Books.Include(x => x.Genre).Include(x => x.Author).Where(b => b.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Belirttiğiniz kitap bulunamadı");
            BookDetailVM vm = _mapper.Map<BookDetailVM>(book);
            return vm;

            #region Before Mapping
            //new BookDetailViewModel{
            //     Title=book.Title,
            //     Genre=((GenreEnum)book.GenreId).ToString(),
            //     PublishedDate=book.PublishedDate.Date.ToString("dd/MM/yyy"),
            //     PageCount=book.PageCount
            // };  
            #endregion

        }
    }
}