using System.ComponentModel.DataAnnotations;

namespace TaskApi.Models;

public enum TaskStatus
{
    Pending,
    InProgress,
    Completed,
    Cancelled
}

public class TodoTask
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required]
    public TaskStatus Status { get; set; } = TaskStatus.Pending;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? DueDate { get; set; }
}