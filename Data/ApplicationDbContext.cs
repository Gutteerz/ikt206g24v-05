using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Example.Models;

namespace Example.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Review> Reviews => Set<Review>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuring author entity
        modelBuilder.Entity<Author>(entity => 
        {
            // Setting Id as primary key
            entity.HasKey(e => e.Id);

            // Configuring the Id to use value generated on add
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });
    }
}
