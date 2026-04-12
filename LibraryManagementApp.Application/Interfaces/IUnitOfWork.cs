namespace LibraryManagementApp.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBookRepository BookRepository { get; }
    IAuthorRepository AuthorRepository { get; }
    Task<int> SaveChangesAsync();
}