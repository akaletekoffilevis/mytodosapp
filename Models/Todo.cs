using System.ComponentModel.DataAnnotations;

namespace TodosApp.Models;

public class Todo
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [MaxLength(500)]
    public string? Description { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? DueDate { get; set; }
}