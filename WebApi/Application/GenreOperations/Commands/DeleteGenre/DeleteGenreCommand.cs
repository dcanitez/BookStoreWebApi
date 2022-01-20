using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly BookStoreDbContext context;

        public int GenreId { get; set; }

        public DeleteGenreCommand(BookStoreDbContext context)
        {
            this.context = context;

        }

        public void Handle()
        {
            var genre = context.Genres.SingleOrDefault(x => x.GenreId == GenreId);
            if (genre is null)
                throw new Exception("Belirtilen kategori bulunamadı");
            context.Genres.Remove(genre);
            context.SaveChanges();
        }
    }

}