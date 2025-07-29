using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Models;

namespace TodoApp.Api.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        // will do

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //     base.OnConfiguring(optionsBuilder);
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(200)
                .IsRequired();

                entity.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(500);

                entity.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CompletedAt)
                .HasColumnName("completed_at");

                entity.HasIndex(e => e.CreatedAt)
                .HasDatabaseName("ix_todos_created_at");

                entity.HasIndex(e => e.CompletedAt)
                .HasDatabaseName("ix_todos_is_completed");
            });


            modelBuilder.Entity<Todo>().HasData(
                new Todo
                {
                    Id = 1,
                    Title = "Learn EF Core",
                    Description = "Master Entity Framework Core with PostgreSQL",
                    IsCompleted = false,
                    CreatedAt = DateTime.UtcNow
                },
                new Todo
                {
                    Id = 2,
                    Title = "Build Todo API",
                    Description = "Create a RESTful API with CRUD operations",
                    IsCompleted = true,
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    CompletedAt = DateTime.UtcNow
                }
            );
        }
    }
}