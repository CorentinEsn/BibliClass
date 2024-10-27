using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BibliClass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Tag> Tags { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Tags = new List<Tag>
            {
                new Tag { Name = "Tag1" },
                new Tag { Name = "Tag2" },
                new Tag { Name = "Tag3" }
            };
            DataContext = this;
        }

    }
}