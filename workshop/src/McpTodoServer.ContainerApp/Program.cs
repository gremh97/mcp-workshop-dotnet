
using Microsoft.EntityFrameworkCore;
using McpTodoServer.ContainerApp.Data;
using McpTodoServer.ContainerApp.Repositories;
using McpTodoServer.ContainerApp.Services;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Configure EF Core with in-memory SQLite (persistent for app lifetime)
var sqliteConnection = new SqliteConnection("DataSource=:memory:");
sqliteConnection.Open();
builder.Services.AddSingleton(sqliteConnection);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(sqliteConnection)
);


// Register repository and service
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<TodoService>();

// 👇👇👇 Add 👇👇👇
builder.Services.AddMcpServer()
                .WithHttpTransport(o => o.Stateless = true)
                .WithToolsFromAssembly();
// 👆👆👆 Add 👆👆👆
var app = builder.Build();

// Initialize database at app start
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}



// 👇👇👇 Add 👇👇👇
app.MapMcp("/mcp");
// 👆👆👆 Add 👆👆👆
app.Run();
