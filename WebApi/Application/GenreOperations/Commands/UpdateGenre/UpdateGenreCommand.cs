using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public int GenreId { get; set; }
        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _dbContext = context;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.GenreId == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Düzenlemek istenilen kategori bulunamadı");
            if (_dbContext.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.GenreId != GenreId))
                throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcuttur.");


            genre.Name = string.IsNullOrEmpty(Model.Name) == default ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _dbContext.SaveChanges();
        }

        public class UpdateGenreModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}