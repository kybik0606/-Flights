using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

public class PeopleModel : PageModel
{
    private readonly MyDbContext _context;

    public PeopleModel(MyDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public string Name { get; set; }

    public List<Person> PeopleList { get; set; }

    public void OnGet()
    {
        PeopleList = _context.People.ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            _context.People.Add(new Person { Name = Name });
            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }
}
