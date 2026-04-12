namespace LibraryManagementApp.Domain.Entities;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = null!;
    public Guid AuthorId { get; private set; }
    public int Stock{get; private set;}

    public Author Author { get; private set; } = null!;

    public Book(Guid id, string title, Guid authorId)
    {
        Id = id;
        Title = title;
        AuthorId = authorId;
    }

    public void Borrow()
    {
        if(Stock == 0)
        {
            throw new InvalidOperationException("Book is out of stock");
        }
        Stock--;
    }

    
}