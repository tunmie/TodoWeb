using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoWeb.Data;
using TodoWeb.Models;

namespace TodoWeb.Pages.Todo;

public class IndexModel : PageModel
{
    private readonly AppDbContext _dbContext;

    public IndexModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [BindProperty]
    public string NewTodo { get; set; }

    public List<Models.Todo> Todos { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        Todos = await _dbContext.Todos.ToListAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAddTodoAsync()
    {
        if (!string.IsNullOrEmpty(NewTodo))
        {
            var todo = new Models.Todo { Title = NewTodo };
            _dbContext.Todos.Add(todo);
            await _dbContext.SaveChangesAsync();
        }

        return RedirectToPage();
    }
    
    public async Task<IActionResult> OnPostDeleteTodoAsync(int todoId)
    {
        var todo = await _dbContext.Todos.FindAsync(todoId);
        if (todo != null)
        {
            _dbContext.Todos.Remove(todo);
            await _dbContext.SaveChangesAsync();
        }

        return RedirectToPage();
    }
}