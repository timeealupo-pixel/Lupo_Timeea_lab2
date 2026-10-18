using Lupo_Timeea_lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lupo_Timeea_lab2.Pages.Books;

public class CreateModel : PageModel
{
    private readonly Lupo_Timeea_lab2Context _context;

    public CreateModel(Lupo_Timeea_lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        LoadDropdowns();
        return Page();
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            LoadDropdowns();
            return Page();
        }

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

    private void LoadDropdowns()
    {
        ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName");
        ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
    }
}