using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lupo_Timeea_lab2.Models;

namespace Lupo_Timeea_lab2.Pages.Categories;

public class IndexModel : PageModel
{
    private readonly Lupo_Timeea_lab2Context _context;

    public IndexModel(Lupo_Timeea_lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Category = await _context.Category.ToListAsync();
    }
}
