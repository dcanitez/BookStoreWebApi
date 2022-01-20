using System;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
    public partial class CreateBookVM
    {

        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }

    }
}