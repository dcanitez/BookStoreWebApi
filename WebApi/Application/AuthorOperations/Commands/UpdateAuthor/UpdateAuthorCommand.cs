using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext context;
        public int AuthorId { get; set; }
        public UpdateAuthorVM Model { get; set; }
        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            this.context = context;
        }

        public void Handle()
        {
            var author = context.Authors.SingleOrDefault(x => x.AuthorId == AuthorId);
            if (author is not null)
            {
                author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;
                author.Name = Model.Name != default ? Model.Name : author.Name;
                author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
                context.SaveChanges();
            }
            else
                throw new InvalidOperationException("Güncellemek istediğiniz yazar bulunamadı");
        }

    }
}
