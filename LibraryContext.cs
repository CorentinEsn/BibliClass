using BibliClass;
using Microsoft.EntityFrameworkCore;

public class LibraryContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public string DbPath { get; }

    public LibraryContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        Console.WriteLine("path : ", path);
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
        modelBuilder.Entity<Tag>()
            .HasKey(t => t.tag);
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
        SaveChanges();
    }

    public Author GetAuthorIDByName(string name)
    {
        Author? auteur;

        auteur = Authors.Where(p => name.Contains(p.Name)) as Author;

        if (auteur == null)
        {
            Authors.Add(auteur = new Author { Name = name });
            this.SaveChanges();
        }
        return auteur;
    }

    public string GetAuthorName(int id)
    {
        return Authors.Single(p => p.Id == id).Name;
    }

    public void AddTag(Tag tag)
    {
        Tags.Add(tag);
        SaveChanges();
    }
}