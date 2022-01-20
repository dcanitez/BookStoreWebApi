using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext context;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            this.context = context;
        }

        public void Handle()
        {
            var author = context.Authors.SingleOrDefault(a => a.AuthorId == AuthorId);
            if (author is not null)
            {
                var bookList = context.Books.Where(a => a.AuthorId == AuthorId).ToList();
                foreach (var item in bookList)
                {
                    if (item.IsOnSale)
                    {
                        throw new InvalidOperationException("Belirtilen yazarın satışta kitabı bulunduğundan silme işleminiz gerçekleştirilemedi");
                    }
                }
                context.Authors.Remove(author);
                context.SaveChanges();
            }
            else
                throw new InvalidOperationException("Belirtilen yazar bulunamadı");

        }

    }
}
