using LibraryManagementApp.Domain.Common;
using LibraryManagementApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    private readonly IPublisher _publisher;
    public AppDbContext(DbContextOptions<AppDbContext> options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // collect domain events
        var entities = ChangeTracker.Entries<BaseEntity>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToList();
        // Save changes to database
        var result = await base.SaveChangesAsync(cancellationToken);

        // publish domain events
        foreach (var entity in entities)
        {
            var domainEvents = entity.DomainEvents.ToList();
            entity.ClearDomainEvents();
            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }
        }

        return result;
    }
}