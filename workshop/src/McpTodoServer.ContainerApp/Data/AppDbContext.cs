using Microsoft.EntityFrameworkCore;
using McpTodoServer.ContainerApp.Models;

namespace McpTodoServer.ContainerApp.Data;

/// <summary>
/// Application database context for to-do items.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the to-do items.
    /// </summary>
    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}
