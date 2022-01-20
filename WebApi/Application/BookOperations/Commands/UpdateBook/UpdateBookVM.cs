using System;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookVM
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public bool IsOnSale { get; set; }
    }

}