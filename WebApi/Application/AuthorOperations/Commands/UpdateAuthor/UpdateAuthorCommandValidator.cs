using FluentValidation;
using System;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0);
            RuleFor(a => a.Model.BirthDate.Date).GreaterThan(DateTime.Now.Date);
            RuleFor(a => a.Model.Name).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(a => a.Model.Surname).NotEmpty().NotNull().MinimumLength(2);
        }
    }
}
