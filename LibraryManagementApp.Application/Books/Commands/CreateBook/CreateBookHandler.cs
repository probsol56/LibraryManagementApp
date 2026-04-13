using LibraryManagementApp.Application.Interfaces;
using LibraryManagementApp.Domain.Entities;
using MediatR;

namespace LibraryManagementApp.Application.Books.Commands.CreateBook;

public class CreateBookHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateBookCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreateBookCommand request, CancellationToken ct)
    {
        var book = new Book(
            Guid.NewGuid(),
            request.Title,
            request.AuthorId,
            request.Stock
        );
        await _unitOfWork.BookRepository.AddAsync(book);
        await _unitOfWork.SaveChangesAsync();
        return book.Id;
    }
}