namespace WebApi.Application.BookOperations.Queries.GetBookDetails
{
    public partial class GetBookByIdQuery
    {
        public class BookDetailVM
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