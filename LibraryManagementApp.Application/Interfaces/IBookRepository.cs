using LibraryManagementApp.Domain.Entities;

namespace LibraryManagementApp.Application.Interfaces;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId);
}