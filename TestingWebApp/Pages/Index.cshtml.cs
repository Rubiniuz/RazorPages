using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using TestingWebApp.Repositories;

namespace TestingWebApp.Pages;

public class IndexModel : PageModel
{
    public IEnumerable<Todo> Todos
    {
        get
        {
            return new TodoRepository().Get();
        }
        /*set
        {
            _todos = TodoRepository().Create();
        }*/
    }

    public List<Todo> TodosList = new List<Todo>();

    public string Description;
    public bool Completed;

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
    }

    /*public void OnPost()
    {
        string description = Request.Form["description"];
        string completed = Request.Form["completed"];
        new TodoRepository().Create(new Todo() { Description = description, Completed = false });
    }*/

    [BindProperty] 
    public Todo TodoToAdd { get; set; }
    
    public IActionResult OnPost()
    {
        //Ohkay but messy
        if(!ModelState.IsValid)
        {
            return Page();
        }
        
        new TodoRepository().Create(TodoToAdd);
        
        return Page();
    }
    public IActionResult OnPostCreate(string description)
    {
        //Wrong!
        if(!ModelState.IsValid)
        {
            if(description != "" && description != null)
            {
                new TodoRepository().Create(new Todo() { Description = description, Completed = false });
            }
        }
        return Page();
    }
    
    public IActionResult OnPostCreateCorrect()
    {
        //Correct
        if(!ModelState.IsValid)
        {
            return Page();
        }
        
        new TodoRepository().Create(TodoToAdd);
        
        return Page();
    }

    public void OnPostDelete(int todoId)
    {
        new TodoRepository().Delete(todoId);
    }

    public void OnPostUpdate(string description, string completed, int todoId)
    {
        new TodoRepository().Update(new Todo() 
            { Description = description, Completed = (completed == "on"), TodoId = todoId });
    }
}