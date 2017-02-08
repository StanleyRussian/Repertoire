using System.Windows;
using DynamicGridManagers;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for vGroupTab.xaml
    /// </summary>
    public partial class vGroupTab
    {
        public vGroupTab()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            GridProgressNodeManager.Initialize(gridSongs);
        }
    }
}