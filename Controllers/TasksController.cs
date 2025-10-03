using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskFlowAPI.Data;
using TaskFlowAPI.DTOs;
using TaskFlowAPI.Models;

namespace TaskFlowAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TasksController : ControllerBase
    {
        private readonly TaskDbContext _context;
        private readonly ILogger<TasksController> _logger;

        public TasksController(TaskDbContext context, ILogger<TasksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            var tasks = await _context.Tasks
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound(new { message = $"Task with ID {id} not found" });
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask([FromBody] CreateTaskDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                Status = TaskFlowAPI.Models.TaskStatus.Todo, 
                DueDate = dto.DueDate,
                CreatedAt = DateTime.UtcNow
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Created new task with ID {TaskId}", task.Id);

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskItem>> UpdateTask(int id, [FromBody] DTOs.UpdateTaskDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound(new { message = $"Task with ID {id} not found" });

            if (!string.IsNullOrEmpty(dto.Title))
                task.Title = dto.Title;

            if (dto.Description != null)
                task.Description = dto.Description;

            if (dto.Status.HasValue)
            {
                task.Status = dto.Status.Value; 
                if (dto.Status.Value == TaskFlowAPI.Models.TaskStatus.Done && !task.CompletedAt.HasValue)
                    task.CompletedAt = DateTime.UtcNow;
            }

            if (dto.Priority.HasValue)
                task.Priority = dto.Priority.Value;

            if (dto.DueDate.HasValue)
                task.DueDate = dto.DueDate.Value;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Updated task with ID {TaskId}", id);

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound(new { message = $"Task with ID {id} not found" });

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Deleted task with ID {TaskId}", id);

            return NoContent();
        }
    }
}
