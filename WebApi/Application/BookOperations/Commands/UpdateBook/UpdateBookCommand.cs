using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public partial class UpdateBookCommand
    {
        public UpdateBookVM Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public UpdateBookCommand(BookStoreDbContext context)
        {
            _dbContext = context;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == BookId);
            if (book is null)
                throw new InvalidOperationException("Belirttiğiniz kitap bulunmamaktadır.");
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.GenreId;
            book.PublishedDate = Model.PublishedDate != default ? Model.PublishedDate : book.PublishedDate;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.AuthorId = Model.AuthorId != default ? Model.AuthorId : book.AuthorId;
            book.IsOnSale = Model.IsOnSale != default ? Model.IsOnSale : book.IsOnSale;
            _dbContext.SaveChanges();
        }
    }
}