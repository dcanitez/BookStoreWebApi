using FluentValidation;

namespace WebApi.Application.BookOperations.Queries.GetBookDetails
{
    public class GetBookDetailsQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookDetailsQueryValidator()
        {
            RuleFor(cmd => cmd.BookId).GreaterThan(0);
        }
    }
}