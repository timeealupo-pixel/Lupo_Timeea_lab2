using Lupo_Timeea_lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lupo_Timeea_lab2.Pages.Borrowings;

public class DetailsModel : PageModel
{
    private readonly Lupo_Timeea_lab2Context _context;

    public DetailsModel(Lupo_Timeea_lab2Context context)
    {
        _context = context;
    }

    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing
            .Include(b => b.Member)
            .Include(b => b.Book)
            .ThenInclude(b => b.Author)
            .FirstOrDefaultAsync(m => m.ID == id);
        if (borrowing == null)
        {
            return NotFound();
        }

        Borrowing = borrowing;
        return Page();
    }
}