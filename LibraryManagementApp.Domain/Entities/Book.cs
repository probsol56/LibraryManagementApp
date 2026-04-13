namespace LibraryManagementApp.Domain.Entities;

public class Book(Guid id, string title, Guid authorId, int stock)
{
    public Guid Id { get; private set; } = id;
    public string Title { get; private set; } = title;
    public Guid AuthorId { get; private set; } = authorId;
    public int Stock { get; private set; } = stock;

    public Author Author { get; private set; } = null!;

    public void Borrow()
    {
        if(Stock == 0)
        {
            throw new InvalidOperationException("Book is out of stock");
        }
        Stock--;
    }

    
}