using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliClass
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonType { get; set; } // "Person", "Student", "Author"
    }

    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public bool IsAvailable { get; set; } = true;
    }

    public class Loan
    {
        public int Id { get; set; }
        public int LoanerId { get; set; }
        public string BookISBN { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
