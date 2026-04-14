using LibraryManagementApp.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryManagementApp.Application.EventHandlers;

public class SendEmailOnBookBorrowedHandler : INotificationHandler<BookBorrowedEvent>
{
    private readonly ILogger<SendEmailOnBookBorrowedHandler> _logger;
    public SendEmailOnBookBorrowedHandler(ILogger<SendEmailOnBookBorrowedHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(BookBorrowedEvent notification, CancellationToken cancellationToken)
    {
        // In real application, we would send an email to the user
        _logger.LogInformation("Book {BookId} borrowed by user {UserId} at {BorrowedAt}", notification.Book.Id, notification.BorrowedByUserId, notification.BorrowedAt);
        return Task.CompletedTask;
    }
}