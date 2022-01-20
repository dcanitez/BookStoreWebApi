using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public partial class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public List<BooksVM> Handle()
        {
            var bookList = _dbContext.Books.Include(g => g.Genre).Include(a => a.Author).OrderBy(b => b.Id).ToList<Book>();
            List<BooksVM> vm = _mapper.Map<List<BooksVM>>(bookList);

            return vm;

            #region Before Mapping
            //List<BooksViewModel> vm = new List<BooksViewModel>();
            // foreach (Book item in bookList)
            // {
            //     vm.Add(new BooksViewModel
            //     {
            //         Title = item.Title,
            //         Genre=((GenreEnum)item.GenreId).ToString(),
            //         PublishedDate=item.PublishedDate.Date.ToString("dd/MM/yyy"),
            //         PageCount=item.PageCount                    
            //     });
            // }  
            #endregion

        }
    }
}