using System.Collections.Generic;
using System.Threading.Tasks;
using McpTodoServer.ContainerApp.Models;

namespace McpTodoServer.ContainerApp.Repositories;

/// <summary>
/// Defines repository operations for to-do items.
/// </summary>
public interface ITodoRepository
{
    Task<TodoItem> CreateAsync(TodoItem item);
    Task<List<TodoItem>> ListAsync();
    Task<TodoItem?> UpdateAsync(TodoItem item);
    Task<TodoItem?> CompleteAsync(int id);
    Task<bool> DeleteAsync(int id);
}
