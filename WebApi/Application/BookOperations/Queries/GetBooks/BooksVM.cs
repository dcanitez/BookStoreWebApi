namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public partial class GetBooksQuery
    {
        public class BooksVM
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishedDate { get; set; }
            public string Genre { get; set; }
            public string AuthorFullName { get; set; }
            public bool IsOnSale { get; set; }
        }
    }
}