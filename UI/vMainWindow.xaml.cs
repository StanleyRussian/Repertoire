using System.Windows;
using Repertoire;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class vMainWindow
    {
        public vMainWindow()
        {
            InitializeComponent();
            DataContext = new vmMainWindow();
        }
    }
}
