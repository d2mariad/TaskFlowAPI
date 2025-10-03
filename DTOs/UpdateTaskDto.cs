using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskFlowAPI.Models;

namespace TaskFlowAPI.DTOs
{
    public class UpdateTaskDto
    {
        [StringLength(200, MinimumLength = 3)]
        public string? Title { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TaskFlowAPI.Models.TaskStatus? Status { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TaskFlowAPI.Models.TaskPriority? Priority { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
