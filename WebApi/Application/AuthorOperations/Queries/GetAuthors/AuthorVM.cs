using System;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public partial class GetAuthorsQuery
    {
        public class AuthorVM
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string BirthDate { get; set; }
        }
    }
}
