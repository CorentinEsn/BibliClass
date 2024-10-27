    public class Person
    {
        public int Id {  get; set; }
        public string? FirstName {  get; set; }
        public required string LastName {  get; set; }
    public ICollection<Loan>? Loans { get; set; }

}
