using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public partial class GetAuthorsQuery
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<AuthorVM> Handle()
        {
            var authors = context.Authors.OrderBy(a => a.AuthorId).ToList<Author>();
            List<AuthorVM> list = mapper.Map<List<AuthorVM>>(authors);
            return list;
        }
    }
}
