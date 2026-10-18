using Microsoft.EntityFrameworkCore;

public class Lupo_Timeea_lab2Context(DbContextOptions<Lupo_Timeea_lab2Context> options) : DbContext(options)
{
    public DbSet<Lupo_Timeea_lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Lupo_Timeea_lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Lupo_Timeea_lab2.Models.Author> Author { get; set; } = default!;
}
