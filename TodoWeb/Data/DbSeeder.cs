using Microsoft.EntityFrameworkCore;
using TodoWeb.Models;

namespace TodoWeb.Data;

public static class DbSeeder
{
    public static void SeedData(AppDbContext dbContext)
    {
        // Check if data already exists
        if (dbContext.Todos.Any())
        {
            // Data already seeded
            return;
        }

        // Add sample todos
        var todos = new Todo[]
        {
            new Todo { Title = "Buy groceries", IsCompleted = false, CreatedAt = DateTime.UtcNow },
            new Todo { Title = "Finish homework", IsCompleted = true, CreatedAt = DateTime.UtcNow },
            new Todo { Title = "Go for a run", IsCompleted = false, CreatedAt = DateTime.UtcNow }
        };

        dbContext.Todos.AddRange(todos);
        dbContext.SaveChanges();
    }
}
