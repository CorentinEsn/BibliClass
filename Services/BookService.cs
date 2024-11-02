using Microsoft.EntityFrameworkCore;

public class BookService
{
    private readonly LibraryContext _context;

    public BookService(LibraryContext context)
    {
        _context = context;
    }

    public void CreateBook(string isbn, string title, string? authorFirstName, string? authorLastName, List<string>? tagNames)
    {
        var author = new Author
        {
            FirstName = authorFirstName,
            LastName = authorLastName
        };

        // Rechercher les tags existants ou les créer si nécessaire
        var tags = tagNames.Select(tagName =>
            _context.Tags.FirstOrDefault(t => t.Name == tagName) ?? new Tag { Name = tagName }).ToList();

        var book = new Book
        {
            ISBN = isbn,
            Title = title,
            Author = author,
            Tags = tags
        };

        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void CreateBook(string isbn, string title, Author? author, List<string>? tagNames)
    {
        // Rechercher les tags existants ou les créer si nécessaire
        var tags = tagNames.Select(tagName =>
            _context.Tags.FirstOrDefault(t => t.Name == tagName) ?? new Tag { Name = tagName }).ToList();

        var book = new Book
        {
            ISBN = isbn,
            Title = title,
            Author = author,
            Tags = tags
        };

        _context.Books.Add(book);
        _context.SaveChanges();
    }

    internal void CreateBook(string isbn, string title)
    {
        var book = new Book
        {
            ISBN = isbn,
            Title = title,
        };

        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public Book ReadBook(string bookId)
    {
        return _context.Books
            .Include(b => b.Author)
            .Include(b => b.Tags)
            .FirstOrDefault(b => b.ISBN == bookId);
    }

    public void UpdateBook(string bookId, string newTitle, string newAuthorFirstName, string newAuthorLastName, List<string> newTagNames)
    {
        var book = _context.Books
            .Include(b => b.Author)
            .Include(b => b.Tags)
            .FirstOrDefault(b => b.ISBN == bookId);

        if (book != null)
        {
            book.Title = newTitle;
            book.Author.FirstName = newAuthorFirstName;
            book.Author.LastName = newAuthorLastName;

            // Vérification des tags existants ou création de nouveaux si nécessaire
            book.Tags = newTagNames.Select(tagName =>
                _context.Tags.FirstOrDefault(t => t.Name == tagName) ?? new Tag { Name = tagName }).ToList();

            _context.SaveChanges();
        }
    }

    public void DeleteBook(int bookId)
    {
        var book = _context.Books.Find(bookId);

        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }

    public List<Book> ReadAllBooks()
    {
        return _context.Books
            .Include(b => b.Author)
            .Include(b => b.Tags)
            .ToList();
    }
    public List<Tag> ReadAllTags()
    {
        return _context.Tags.ToList();
    }
}
