using FluentValidation;
using System;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(cmd => cmd.Model.PageCount).GreaterThan(0);
            RuleFor(cmd => cmd.Model.PublishedDate.Date).NotEmpty().LessThan(DateTime.Now);
            RuleFor(cmd => cmd.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}