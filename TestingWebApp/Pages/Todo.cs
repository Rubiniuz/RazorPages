using System.ComponentModel.DataAnnotations;

namespace TestingWebApp.Pages;

public class Todo
{
    public int TodoId { get; set; }
    [Required, MinLength(1), MaxLength(20)]
    public string Description { get; set; }
    public bool Completed { get; set; }
}