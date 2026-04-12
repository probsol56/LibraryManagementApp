using LibraryManagementApp.Application.Interfaces;
using LibraryManagementApp.Domain.Entities;

namespace LibraryManagementApp.Application.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;

    public BookService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Book?> GetBookByIdAsync(Guid id)
    {
        return await _unitOfWork.BookRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _unitOfWork.BookRepository.GetAllAsync();
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        return await _unitOfWork.BookRepository.AddAsync(book);
    }

    public void UpdateBook(Book book)
    {
        _unitOfWork.BookRepository.Update(book);
    }

    public void DeleteBook(Book book)
    {
        _unitOfWork.BookRepository.Delete(book);
    }

    public async Task BorrowBookAsync(Guid bookId)
    {
        var book = await _unitOfWork.BookRepository.GetByIdAsync(bookId);
        if (book == null)
        {
            throw new Exception("Book not found");
        }
        if (book.Stock == 0)
        {
            throw new InvalidOperationException("Book is out of stock");
        }
        book.Stock--;
        _unitOfWork.BookRepository.Update(book);
        await _unitOfWork.SaveChangesAsync();
    }
}