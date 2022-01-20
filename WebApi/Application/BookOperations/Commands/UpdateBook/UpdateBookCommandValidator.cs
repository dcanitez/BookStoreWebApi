using FluentValidation;
using System;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(cmd => cmd.Model.GenreId).GreaterThan(0);
            RuleFor(cmd => cmd.Model.PageCount).GreaterThan(0);
            RuleFor(cmd => cmd.Model.PublishedDate.Date).LessThan(DateTime.Now).NotEmpty();
            RuleFor(cmd => cmd.Model.Title).MinimumLength(2).NotNull().NotEmpty();
        }
    }
}