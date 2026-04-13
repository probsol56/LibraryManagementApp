using LibraryManagementApp.Application.Interfaces;
using LibraryManagementApp.Domain.Entities;
using MediatR;

namespace LibraryManagementApp.Application.Books.Queries.GetAllBooks;

public class GetAllBooksHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken ct)
    {
        return await _unitOfWork.BookRepository.GetAllAsync();
    }

}