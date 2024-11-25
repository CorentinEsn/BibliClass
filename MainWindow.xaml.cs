using BibliClass.Pages;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace BibliClass
{
    public partial class MainWindow : Window
    {
        private readonly LibraryContext _context;
        //public List<Book> Books { get; set; } = [];

        public MainWindow()
        {
            InitializeComponent();
            _context = new LibraryContext();
            LoadBooks();
        }

        private void LoadBooks()
        {
            var books = _context.Books.ToList();
            DataContext = books; // Ou configure un autre DataContext approprié
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
            var addBookWindow = new AddBook
            {
                Owner = this
            };
            ClickAnimation(sender, e);
            addBookWindow.ShowDialog();
        }

        public void BookTileClic(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Book clicked !");
            ClickAnimation(sender, e);
            //Books.Clear();
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