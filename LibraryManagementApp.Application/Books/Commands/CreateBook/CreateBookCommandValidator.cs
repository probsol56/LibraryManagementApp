using FluentValidation;

namespace LibraryManagementApp.Application.Books.Commands.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty()
        .WithMessage("Title is required")
        .MaximumLength(200).WithMessage("Title must be less than 200 characters");
        RuleFor(x => x.AuthorId).NotNull().NotEmpty().WithMessage("AuthorId is required");
        RuleFor(x => x.Stock).NotEmpty().WithMessage("Stock is required").GreaterThan(0).WithMessage("Stock must be greater than 0");
    }
}