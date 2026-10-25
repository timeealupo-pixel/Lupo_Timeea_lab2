using Lupo_Timeea_lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lupo_Timeea_lab2.Pages.Books;

public class CreateModel : BookCategoriesPageModel
{
    private readonly Lupo_Timeea_lab2Context _context;

    public CreateModel(Lupo_Timeea_lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        LoadDropdowns();

        var book = new Book();
        book.BookCategories = new List<BookCategory>();
        PopulateAssignedCategoryData(_context, book);
        return Page();
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
    {
        var newBook = new Book();
        if (selectedCategories != null)
        {
            newBook.BookCategories = new List<BookCategory>();
            foreach (var cat in selectedCategories)
            {
                var catToAdd = new BookCategory
                {
                    CategoryID = int.Parse(cat)
                };
                newBook.BookCategories.Add(catToAdd);
            }
        }
        Book.BookCategories = newBook.BookCategories;
        _context.Book.Add(Book);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }

    private void LoadDropdowns()
    {
        var authorList = _context.Author.Select(x => new
        {
            x.ID,
            FullName = x.LastName + " " + x.FirstName
        });
        ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
        ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
    }
}