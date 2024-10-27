    public class Book
    {
        public required string ISBN { get; set; }
        public required string Title { get; set; }
    public int AuthorId {  get; set; }
        public Author ?Author { get; set; }
    public bool IsAvailable { get; set; } = true;
        public ICollection<Tag>? Tags { get; set; }
    public ICollection<Loan> Loans { get; set; }

        public void AddTag(Tag tag)
        {
            Tags.Add(tag);
        }
    }
