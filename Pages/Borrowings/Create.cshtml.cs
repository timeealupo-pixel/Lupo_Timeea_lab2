using Lupo_Timeea_lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lupo_Timeea_lab2.Pages.Borrowings;

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
    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            LoadDropdowns();
            return Page();
        }

        _context.Borrowing.Add(Borrowing);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

    private void LoadDropdowns()
    {
        var books = _context.Book
            .Include(b => b.Author)
            .ToList();

        var bookList = books.Select(x => new
        {
            x.ID,
            BookFullName = x.Title + " - " + x.Author?.LastName + " " + x.Author?.FirstName
        });

        ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
    }
}