

namespace LibraryManagementApp.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    // Private list to store domain events. Only the entity itself can add domain events.
    private readonly List<IDomainEvent> _domainEvents = new();
    
    // Public read-only list to access domain events. Only read access for other layers.
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    
    // Method to register domain events
    public void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}