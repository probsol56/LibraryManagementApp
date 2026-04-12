using LibraryManagementApp.Application.Interfaces;
using LibraryManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.Infrastructure.Persistence.Repositories;

public class BookRepository(AppDbContext context) : GenericRepository<Book>(context), IBookRepository
{

    public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId)
    {
        return await _context.Books.Where(b => b.AuthorId == authorId).ToListAsync();
    }
}