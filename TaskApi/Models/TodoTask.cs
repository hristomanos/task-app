using System.ComponentModel.DataAnnotations;

namespace TaskApi.Models;

public enum TaskStatus
{
    Pending,
    InProgress,
    Completed
}

public class TodoTask
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    public TaskStatus Status { get; set; } = TaskStatus.Pending;

    [Required]
    public DateTime DueDate { get; set; }
}