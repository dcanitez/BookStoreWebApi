using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public partial class CreateAuthorCommand
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public CreateAuthorVM Model { get; set; }
        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Handle()
        {
            var author = context.Authors.SingleOrDefault(a => a.Name == Model.Name && a.Surname == Model.Surname);
            if (author is null)
            {
                mapper.Map<Author>(Model);
                context.Authors.Add(author);
                context.SaveChanges();
            }
            else
                throw new Exception("Belirttiğiniz isim ve soyisimde bir yazar bulunmaktadır.");
        }
    }
}
