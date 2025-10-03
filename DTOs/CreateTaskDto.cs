using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskFlowAPI.Models;

namespace TaskFlowAPI.DTOs
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        public DateTime? DueDate { get; set; }
    }
}
