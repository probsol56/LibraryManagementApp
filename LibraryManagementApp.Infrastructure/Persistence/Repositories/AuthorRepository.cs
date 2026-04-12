using LibraryManagementApp.Application.Interfaces;
using LibraryManagementApp.Domain.Entities;

namespace LibraryManagementApp.Infrastructure.Persistence.Repositories;

public class AuthorRepository(AppDbContext context) : GenericRepository<Author>(context), IAuthorRepository
{
}