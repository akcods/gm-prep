using api.Model;
using Microsoft.EntityFrameworkCore;

public class BookDbContext : DbContext
{
    public DbSet<Book> books { get; set; }

    public BookDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>();
    }
}