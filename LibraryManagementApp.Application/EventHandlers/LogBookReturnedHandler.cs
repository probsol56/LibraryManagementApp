using LibraryManagementApp.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagementApp.Application.EventHandlers;

public class LogBookReturnedHandler : INotificationHandler<BookReturnedEvent>
{
    private readonly ILogger<LogBookReturnedHandler> _logger;
    public LogBookReturnedHandler(ILogger<LogBookReturnedHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(BookReturnedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Book {BookId} returned at {ReturnedAt}", notification.Book.Id, notification.ReturnedAt);
        return Task.CompletedTask;
    }
}