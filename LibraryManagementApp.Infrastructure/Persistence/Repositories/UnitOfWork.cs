using LibraryManagementApp.Application.Interfaces;

namespace LibraryManagementApp.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IBookRepository? _books;
    private IAuthorRepository? _authors;

    

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public IBookRepository BookRepository => _books ??= new BookRepository(_context);
    public IAuthorRepository AuthorRepository => _authors ??= new AuthorRepository(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}