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
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Book> Books { get; set; } = new List<Book>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void tagClick(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Tag clicked !");
            ClickAnimation(sender, e);
        }

        public void AddBookTileClick(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Add Book !");
            ClickAnimation(sender, e);
            Books.Add(new Book { ISBN = "abcd", Title = "Tintin Au Congo" });
        }

        public void BookTileClic(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Book clicked !");
            ClickAnimation(sender, e);
            Books.Clear();
        }

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