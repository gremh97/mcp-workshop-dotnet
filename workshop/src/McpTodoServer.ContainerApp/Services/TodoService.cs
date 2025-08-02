using System.Collections.Generic;
using System.Threading.Tasks;
using McpTodoServer.ContainerApp.Models;
using McpTodoServer.ContainerApp.Repositories;

namespace McpTodoServer.ContainerApp.Services;

/// <summary>
/// Service layer for to-do list business logic.
/// </summary>
public class TodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<TodoItem> CreateAsync(string text)
    {
        var item = new TodoItem { Text = text, IsCompleted = false };
        return await _repository.CreateAsync(item);
    }

    public async Task<List<TodoItem>> ListAsync()
    {
        return await _repository.ListAsync();
    }

    public async Task<TodoItem?> UpdateAsync(int id, string text)
    {
        var item = await _repository.UpdateAsync(new TodoItem { ID = id, Text = text });
        return item;
    }

    public async Task<TodoItem?> CompleteAsync(int id)
    {
        return await _repository.CompleteAsync(id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
