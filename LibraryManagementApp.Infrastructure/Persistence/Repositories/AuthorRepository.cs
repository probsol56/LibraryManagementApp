using LibraryManagementApp.Application.Interfaces;
using LibraryManagementApp.Domain.Entities;

namespace LibraryManagementApp.Infrastructure.Persistence.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }
}