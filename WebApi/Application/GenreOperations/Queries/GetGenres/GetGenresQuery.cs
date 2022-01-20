using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<GenreVM> Handle()
        {
            var genres = context.Genres.Where(g => g.IsActive).OrderBy(g => g.GenreId);
            List<GenreVM> returnObj = mapper.Map<List<GenreVM>>(genres);
            return returnObj;
        }

    }
    public class GenreVM
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
    }
}
