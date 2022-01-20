using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public int GenreId { get; set; }

        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public GenreDetailVM Handle()
        {
            var genre = context.Genres.SingleOrDefault(g => g.GenreId == GenreId && g.IsActive == true);
            if (genre is null)
                throw new InvalidOperationException("Kitap türü bulunamadı");
            GenreDetailVM vm = mapper.Map<Genre, GenreDetailVM>(genre);
            return vm;
        }

        public class GenreDetailVM
        {
            public int GenreId { get; set; }
            public string Name { get; set; }
        }
    }

}

