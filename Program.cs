using Microsoft.EntityFrameworkCore;
using TaskFlowAPI.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseInMemoryDatabase("TaskFlowDb"));


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


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskFlow API v1");
        c.RoutePrefix = string.Empty; 
    });
}


app.UseCors("AllowAll");

// ? Optional: redirect root to Swagger UI (if you want)
app.MapGet("/", () => Results.Redirect("/swagger"));


if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();


app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    context.Database.EnsureCreated(); 
   
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


public partial class Program { }
