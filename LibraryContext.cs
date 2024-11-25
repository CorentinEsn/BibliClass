using BibliClass;
using Microsoft.EntityFrameworkCore;

public class LibraryContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }

    public string DbPath { get; }

    public LibraryContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "library.db");
    }


    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasKey(b => b.ISBN); // Assurez-vous que la clé primaire est configurée
    }

}
