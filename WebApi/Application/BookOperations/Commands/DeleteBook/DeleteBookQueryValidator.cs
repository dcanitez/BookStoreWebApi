using FluentValidation;

namespace WebApi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookQueryValidator : AbstractValidator<DeleteBookQuery>
    {
        public DeleteBookQueryValidator()
        {
            RuleFor(cmd => cmd.BookId).GreaterThanOrEqualTo(0);
        }
    }
}