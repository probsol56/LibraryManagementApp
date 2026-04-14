using LibraryManagementApp.Domain.Common;
using LibraryManagementApp.Domain.Events;

namespace LibraryManagementApp.Domain.Entities;

public class Book:BaseEntity
{
    public string Title { get; private set; } = null!;
    public Guid AuthorId { get; private set; } 
    public int Stock { get; private set; } 
    public bool IsAvailable { get; private set; } 

    public Author Author { get; private set; } = null!;

    public void Borrow(Guid userId)
    {
        if(Stock == 0)
        {
            throw new InvalidOperationException("Book is out of stock");
        }
        Stock--;
        IsAvailable = Stock > 0;
        RaiseDomainEvent(new BookBorrowedEvent(this, userId, DateTime.UtcNow));
    }

    public void Return()
    {
        Stock++;
        IsAvailable = Stock > 0;
        RaiseDomainEvent(new BookReturnedEvent(this, DateTime.UtcNow));
    }

    
}