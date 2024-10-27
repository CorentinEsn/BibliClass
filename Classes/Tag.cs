public class Tag
{
    public required string Name { get; set; }
    public ICollection<Book> Books { get; set; }
}
