using LibraryManagementApp.Domain.Common;
using LibraryManagementApp.Domain.Entities;

namespace LibraryManagementApp.Domain.Events;

public sealed record BookReturnedEvent(Book Book, DateTime ReturnedAt) : IDomainEvent;