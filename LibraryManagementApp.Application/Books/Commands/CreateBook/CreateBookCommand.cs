using MediatR;

namespace LibraryManagementApp.Application.Books.Commands.CreateBook;

public record CreateBookCommand(
    string Title,
    Guid AuthorId,
    int Stock
) : IRequest<Guid>;