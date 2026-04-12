using LibraryManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
}