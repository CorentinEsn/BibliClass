using System.ComponentModel;

namespace BibliClass
{
    public class Author : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private List<Book> books;
        public int Id
        {
            get { return this.id; }
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.NotifyPropertyChanged("Id");
                }
            }
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }
        public List<Book> Books { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }

    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public bool IsAvailable { get; set; } = true;
        public List<Tag> Tags { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }

    public class Loan
    {
        public int Id { get; set; }
        public string Loaner { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class Tag
    {
        public string tag { get; set; }

        public Tag(string tag)
        {
            this.tag = tag;
        }
    }
}
