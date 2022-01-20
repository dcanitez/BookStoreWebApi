using FluentValidation;
using System;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(a => a.Model.BirthDate.Date).GreaterThan(DateTime.Now.Date);
            RuleFor(a => a.Model.Name).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(a => a.Model.Surname).NotEmpty().NotNull().MinimumLength(2);

        }
    }
}
