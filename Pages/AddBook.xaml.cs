using System.Windows;

namespace BibliClass.Pages
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private BookService bookService;
        public AddBook(BookService bookService)
        {
            InitializeComponent();
            this.bookService = bookService;
        }

        private void validateForm(object sender, RoutedEventArgs e)
        {
            //get infos from textboxes
            if (Titre.Text != "" && ISBN.Text != "")
            {
                bookService.CreateBook(ISBN.Text, Titre.Text);
                closeWindow(sender, e);
            }
        }

        private void closeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
