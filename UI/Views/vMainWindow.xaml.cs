using Repertoire.ViewModels;

namespace UI.Views
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
