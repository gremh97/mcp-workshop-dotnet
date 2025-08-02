using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McpTodoServer.ContainerApp.Data;
using McpTodoServer.ContainerApp.Models;
using Microsoft.EntityFrameworkCore;

// 👇👇👇 Add 👇👇👇
using ModelContextProtocol.Server;
using System.ComponentModel;
// 👆👆👆 Add 👆👆👆

namespace McpTodoServer.ContainerApp.Tools;

/// <summary>
/// Provides direct to-do list management operations.
/// </summary>
// 👇👇👇 Add 👇👇👇
[McpServerToolType]
// 👆👆👆 Add 👆👆👆
public class TodoTool
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="TodoTool"/> class.
    /// </summary>
    /// <param name="context">The application database context.</param>
    public TodoTool(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new to-do item.
    /// </summary>
    /// <param name="text">The text of the to-do item.</param>
    /// <returns>The created to-do item.</returns>
    // 👇👇👇 Add 👇👇👇
    [McpServerTool(Name = "add_todo_item", Title = "Add a to-do item")]
    [Description("Adds a to-do item to database.")]
    // 👆👆👆 Add 👆👆👆
    public async Task<TodoItem> CreateAsync(string text)
    {
        var item = new TodoItem { Text = text, IsCompleted = false };
        await _context.TodoItems.AddAsync(item);
        await _context.SaveChangesAsync();
        return item;
    }

    /// <summary>
    /// Lists all to-do items.
    /// </summary>
    /// <returns>A list of to-do items.</returns>
    // 👇👇👇 Add 👇👇👇
    [McpServerTool(Name = "get_todo_items", Title = "Get a list of to-do items")]
    [Description("Gets a list of to-do items from database.")]
    // 👆👆👆 Add 👆👆👆
    public async Task<List<TodoItem>> ListAsync()
    {
        return await _context.TodoItems.ToListAsync();
    }

    /// <summary>
    /// Updates the text of a to-do item.
    /// </summary>
    /// <param name="id">The ID of the to-do item.</param>
    /// <param name="text">The new text.</param>
    /// <returns>The updated to-do item, or null if not found.</returns>
    // 👇👇👇 Add 👇👇👇
    [McpServerTool(Name = "update_todo_item", Title = "Update a to-do item")]
    [Description("Updates a to-do item in the database.")]
    // 👆👆👆 Add 👆👆👆
    public async Task<TodoItem?> UpdateAsync(int id, string text)

    {
        var item = await _context.TodoItems.FindAsync(id);
        if (item == null) return null;
        item.Text = text;
        await _context.SaveChangesAsync();
        return item;
    }

    /// <summary>
    /// Marks a to-do item as completed.
    /// </summary>
    /// <param name="id">The ID of the to-do item.</param>
    /// <returns>The completed to-do item, or null if not found.</returns>
    // 👇👇👇 Add 👇👇👇
    [McpServerTool(Name = "complete_todo_item", Title = "Complete a to-do item")]
    [Description("Completes a to-do item in the database.")]
    // 👆👆👆 Add 👆👆👆
    public async Task<TodoItem?> CompleteAsync(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if (item == null) return null;
        item.IsCompleted = true;
        await _context.SaveChangesAsync();
        return item;
    }

    /// <summary>
    /// Deletes a to-do item.
    /// </summary>
    /// <param name="id">The ID of the to-do item.</param>
    /// <returns>True if deleted, false if not found.</returns>
    // 👇👇👇 Add 👇👇👇
    [McpServerTool(Name = "delete_todo_item", Title = "Delete a to-do item")]
    [Description("Deletes a to-do item from the database.")]
    // 👆👆👆 Add 👆👆👆
    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if (item == null) return false;
        _context.TodoItems.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }
}
