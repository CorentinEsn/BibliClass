public class Loan
{
    public int id { get; set; }
    public int LoanerId { get; set; }
    public string BookISBN { get; set; }
    public required Person Loaner { get; set; }
    public required Book Book { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}
