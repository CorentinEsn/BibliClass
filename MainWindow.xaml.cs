using BibliClass.Pages;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace BibliClass
{
    public partial class MainWindow : Window
    {
        private readonly LibraryContext _context;
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Tag> Tags { get; set; }
        public ObservableCollection<Author> Authors { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            _context = new LibraryContext();

            Books = (ObservableCollection<Book>)[.. _context.Books];
            Tags = (ObservableCollection<Tag>)[.. _context.Tags];
            Authors = (ObservableCollection<Author>)[.. _context.Authors];

            bookListDisplay.ItemsSource = Books;
            tagsDisplay.ItemsSource = Tags;

            /*if (Books.Count() > 0)
            {
                AddBook.Visibility = Visibility.Collapsed;
            }*/

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
            var addBookWindow = new AddBook(this._context)
            {
                Owner = this
            };
            ClickAnimation(sender, e);
            if (addBookWindow.ShowDialog() == true)
            {
                Book bookToAdd = addBookWindow.Answer;
                this._context.AddBook(bookToAdd);
                this.Books.Add(bookToAdd);
            }
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