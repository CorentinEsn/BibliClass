using Microsoft.EntityFrameworkCore;

public class LibraryContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=library.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure TPH pour Person, Student, et Author
        modelBuilder.Entity<Person>()
            .HasDiscriminator<string>("PersonType")
            .HasValue<Student>("Student")
            .HasValue<Author>("Author");

        // Configuration de la clé composite pour Loan
        modelBuilder.Entity<Loan>()
            .HasKey(l => new { l.LoanerId, l.BookId });

        // Relations entre Loan, Person et Book
        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Loaner)
            .WithMany(s => s.Loans)
            .HasForeignKey(l => l.LoanerId);

        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Book)
            .WithMany(b => b.Loans)
            .HasForeignKey(l => l.BookId);

        // Relation entre Book et Author
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);

        // Relation entre Book et Tags
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Tags)
            .WithMany(t => t.Books);
    }
}
