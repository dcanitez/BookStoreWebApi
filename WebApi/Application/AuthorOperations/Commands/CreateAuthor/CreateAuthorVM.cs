using System;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public partial class CreateAuthorCommand
    {
        public class CreateAuthorVM
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime BirthDate { get; set; }
        }
    }
}
