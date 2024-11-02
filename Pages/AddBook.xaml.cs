using System.Reflection.PortableExecutable;
using System.Windows;

namespace BibliClass.Pages
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public AddBook()
        {
            InitializeComponent();
        }
        private void validateForm(object sender, RoutedEventArgs e)
        {
                closeWindow(sender, e);
        }

        private void closeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
