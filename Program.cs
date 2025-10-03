using Microsoft.EntityFrameworkCore;
using TaskFlowAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext with In-Memory Database
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseInMemoryDatabase("TaskFlowDb"));

// ? Add CORS policy so frontend can access API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// ? Enable Swagger UI in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskFlow API v1");
        c.RoutePrefix = string.Empty; // Swagger at root
    });
}

// ? Use CORS
app.UseCors("AllowAll");

// ? Optional: redirect root to Swagger UI (if you want)
app.MapGet("/", () => Results.Redirect("/swagger"));

// Only use HTTPS redirection in production
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

// ? Map controllers (this is crucial for your TasksController to work!)
app.MapControllers();

// ? Seed the database with initial data (optional, but helpful)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    context.Database.EnsureCreated(); // For InMemory DB, ensures it's initialized
    // Optional: add some default tasks if needed
    if (!context.Tasks.Any())
    {
        context.Tasks.AddRange(
            new TaskFlowAPI.Models.TaskItem
            {
                Id = 1,
                Title = "Sample Task 1",
                Description = "This is a seeded task",
                Status = TaskFlowAPI.Models.TaskStatus.Todo,
                Priority = TaskFlowAPI.Models.TaskPriority.Medium,
                CreatedAt = DateTime.UtcNow
            }
        );
        context.SaveChanges();
    }
}

app.Run();

// Make Program class accessible for integration tests
public partial class Program { }
