using System.ComponentModel.DataAnnotations;
namespace TaskApi.Models;

public class UpdateTaskStatusDto
{
    [Required]
    public TaskStatus Status { get; set; }
}