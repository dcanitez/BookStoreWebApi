using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                    return;
                else
                {
                    context.Authors.AddRange(
                                        new Author
                                        {
                                            Name = "Eric",
                                            Surname = "Ries",
                                            BirthDate = new DateTime(1932, 05, 19)
                                        },
                                        new Author
                                        {
                                            Name = "Charlotte",
                                            Surname = "Perkins",
                                            BirthDate = new DateTime(1890, 01, 01)
                                        },
                                        new Author
                                        {
                                            Name = "Frank",
                                            Surname = "Herbert",
                                            BirthDate = new DateTime(1948, 07, 24)
                                        });

                    context.Genres.AddRange(
                                        new Genre
                                        {
                                            Name = "Personal Growth"
                                        },
                                        new Genre
                                        {
                                            Name = "Science Fiction"
                                        },
                                        new Genre
                                        {
                                            Name = "Novel"
                                        });

                    context.Books.AddRange(
                                        new Book
                                        {
                                            Title = "Lean Startup",
                                            GenreId = 1,
                                            PageCount = 200,
                                            PublishedDate = new DateTime(2001, 06, 12),
                                            IsOnSale = true,
                                            AuthorId = 1

                                        },
                                        new Book
                                        {

                                            Title = "Herland",
                                            GenreId = 2,
                                            PageCount = 250,
                                            PublishedDate = new DateTime(2010, 05, 23),
                                            IsOnSale = false,
                                            AuthorId = 2
                                        },
                                        new Book
                                        {

                                            Title = "Dune",
                                            GenreId = 2,
                                            PageCount = 540,
                                            PublishedDate = new DateTime(2001, 12, 21),
                                            IsOnSale = true,
                                            AuthorId = 3
                                        }
                );
                    context.SaveChanges();
                }
            }
        }
    }
}