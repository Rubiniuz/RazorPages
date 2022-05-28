using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestingWebApp.Pages;

public class Counting : PageModel
{
    public int Count { get; set; }
    
    public void OnGet()
    {
        
    }
    
    public void OnPostIncrement([FromForm] int count)
    {
        Count = count;
        Count++;
    }
    
    public void OnPostDecrement([FromForm] int count)
    {
        Count = count;
        Count--;
    }
}