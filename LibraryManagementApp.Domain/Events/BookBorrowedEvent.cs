using LibraryManagementApp.Domain.Common;
using LibraryManagementApp.Domain.Entities;

namespace LibraryManagementApp.Domain.Events;

public sealed record BookBorrowedEvent(Book Book, Guid BorrowedByUserId, DateTime BorrowedAt) : IDomainEvent;