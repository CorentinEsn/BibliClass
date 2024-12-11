using System.Windows;

namespace BibliClass.Pages
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private readonly LibraryContext _context;
        private Book newBook;
        public AddBook(LibraryContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void validateForm(object sender, RoutedEventArgs e)
        {
            //On Check que tout soit bien rempli
            if (this.Titre.Text == null || this.Auteur.Text == null || this.ISBN.Text == null ||
                this.Titre.Text == "" || this.Auteur.Text == "" || this.ISBN.Text == "")
            {
                //Popup de warning
                MessageBox.Show("Attention à bien remplir toutes les cases !", "Toutes les cases ne sont pas remplies", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            //On ajoute le livre au contexte
            else
            {
                newBook = new Book();
                newBook.ISBN = this.ISBN.Text;
                newBook.Title = this.Titre.Text;
                newBook.Author = _context.GetAuthorIDByName(this.Auteur.Text);
                DialogResult = true;
            }
        }

        private void closeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Book Answer
        {
            get { return this.newBook; }
        }

    }
}
