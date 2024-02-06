using Microsoft.EntityFrameworkCore;

namespace TutorialIntegrationTests.API;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
                    .HasKey(x => x.Id);

        modelBuilder.Entity<Todo>()
                    .Property(x => x.Title)
                    .HasMaxLength(100)
                    .IsRequired();

        modelBuilder.Entity<Todo>()
                    .Property(x => x.Description)
                    .HasMaxLength(100)
                    .IsRequired();

        modelBuilder.Entity<Todo>()
                    .Property(x => x.CreatedAt)
                    .IsRequired();

        modelBuilder.Entity<Todo>()
                    .Property(x => x.Done)
                    .HasDefaultValue(false)
                    .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
