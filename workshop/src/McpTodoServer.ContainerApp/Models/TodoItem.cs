using System.ComponentModel.DataAnnotations;

namespace McpTodoServer.ContainerApp.Models;

/// <summary>
/// Represents a to-do item.
/// </summary>
public class TodoItem
{
    /// <summary>
    /// Gets or sets the unique identifier for the to-do item.
    /// </summary>
    [Key]
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets the text of the to-do item.
    /// </summary>
    [Required]
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the to-do item is completed.
    /// </summary>
    public bool IsCompleted { get; set; }
}
