public class Tag
{
    public string Name { get; set; }
    public ICollection<Book>? Books { get; set; }
}