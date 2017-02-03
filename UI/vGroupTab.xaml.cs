using System;
using System.Windows;
using Repertoire;

namespace UI
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