using BibliClass.Pages;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace BibliClass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LibraryContext context = new LibraryContext();
        public readonly BookService _bookService;
        public List<Tag> Tags { get; set; }
        public List<Book> Books { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _bookService = new BookService(context);
            Books = _bookService.ReadAllBooks();
            Tags = _bookService.ReadAllTags();
            DataContext = this;
        }

        /*                                      */
        /*          Click Actions               */
        /*                                      */
        public void tagClick(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Tag clicked !");
            ClickAnimation(sender, e);
        }

        public void AddBookTileClick(object sender, MouseButtonEventArgs e)
        {
            var addBookWindow = new AddBook(_bookService);
            addBookWindow.Owner = this;
            ClickAnimation(sender, e);
            Books.Add(new Book { ISBN = "abcd", Title = "Tintin Au Congo" });
            addBookWindow.ShowDialog();
        }

        public void BookTileClic(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Book clicked !");
            ClickAnimation(sender, e);
            Books.Clear();
        }

        /*                                      */
        /*          Animation methods           */
        /*                                      */
        private void ClickAnimation(object sender, MouseButtonEventArgs e)
        {
            // Récupérer le storyboard défini dans les ressources de l'application
            Storyboard storyboard = (Storyboard)Application.Current.Resources["ClickAnimation"];
            // Démarrer l'animation sur le border cliqué
            storyboard.Begin((FrameworkElement)sender);
        }

        private void HoverAnimation(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Récupérer le storyboard défini dans les ressources de l'application
            Storyboard storyboard = (Storyboard)Application.Current.Resources["HoverEnterAnimation"];
            // Démarrer l'animation sur le border cliqué
            storyboard.Begin((FrameworkElement)sender);
        }

        private void endHoverAnimation(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Récupérer le storyboard défini dans les ressources de l'application
            Storyboard storyboard = (Storyboard)Application.Current.Resources["HoverLeaveAnimation"];
            // Démarrer l'animation sur le border cliqué
            storyboard.Begin((FrameworkElement)sender);
        }
    }
}