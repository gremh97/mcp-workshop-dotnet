using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using McpTodoServer.ContainerApp.Data;
using McpTodoServer.ContainerApp.Models;

namespace McpTodoServer.ContainerApp.Repositories;

/// <summary>
/// Repository implementation for to-do items.
/// </summary>
public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TodoItem> CreateAsync(TodoItem item)
    {
        var entry = await _context.TodoItems.AddAsync(item);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<List<TodoItem>> ListAsync()
    {
        return await _context.TodoItems.ToListAsync();
    }

    public async Task<TodoItem?> UpdateAsync(TodoItem item)
    {
        var existing = await _context.TodoItems.FindAsync(item.ID);
        if (existing == null) return null;
        existing.Text = item.Text;
        existing.IsCompleted = item.IsCompleted;
        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<TodoItem?> CompleteAsync(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if (item == null) return null;
        item.IsCompleted = true;
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if (item == null) return false;
        _context.TodoItems.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }
}
