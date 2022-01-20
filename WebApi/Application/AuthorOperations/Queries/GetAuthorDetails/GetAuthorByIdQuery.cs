using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetails
{
    public partial class GetAuthorByIdQuery
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public int AuthorId { get; set; }

        public GetAuthorByIdQuery(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public AuthorDetailVM Handle()
        {
            var author = context.Authors.SingleOrDefault(a => a.AuthorId == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Böyle bir yazar bulunmamaktadr.");
            }
            AuthorDetailVM vm = mapper.Map<AuthorDetailVM>(author);
            return vm;
        }
    }
}
