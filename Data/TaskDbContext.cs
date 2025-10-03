using Microsoft.EntityFrameworkCore;
using TaskFlowAPI.Models;

namespace TaskFlowAPI.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure TaskItem entity
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Description)
                      .HasMaxLength(1000);

                // Folosim numele complet ca sa nu existe ambiguitate
                entity.Property(e => e.Status)
                      .IsRequired()
                      .HasConversion<string>();

                entity.Property(e => e.Priority)
                      .IsRequired()
                      .HasConversion<string>();
            });

            // Seed initial data (optional)
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem
                {
                    Id = 1,
                    Title = "Setup development environment",
                    Description = "Install all necessary tools and dependencies",
                    Status = TaskFlowAPI.Models.TaskStatus.Done,
                    Priority = TaskFlowAPI.Models.TaskPriority.High,
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                    CompletedAt = DateTime.UtcNow.AddDays(-1)
                },
                new TaskItem
                {
                    Id = 2,
                    Title = "Create API documentation",
                    Description = "Document all API endpoints using Swagger",
                    Status = TaskFlowAPI.Models.TaskStatus.InProgress,
                    Priority = TaskFlowAPI.Models.TaskPriority.Medium,
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    CompletedAt = null
                }
            );
        }
    }
}
