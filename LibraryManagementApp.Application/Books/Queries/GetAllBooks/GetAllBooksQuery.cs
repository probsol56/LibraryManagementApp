using LibraryManagementApp.Domain.Entities;
using MediatR;

namespace LibraryManagementApp.Application.Books.Queries.GetAllBooks;

public record GetAllBooksQuery : IRequest<IEnumerable<Book>>;