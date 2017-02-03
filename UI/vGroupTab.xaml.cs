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
        private vmGroupTab _context;
        private aDynamicGridManager _gridManager;

        public vGroupTab()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _context = DataContext as vmGroupTab;
            if (_context == null) throw new ArgumentNullException(nameof(_context));

            _gridManager = new GridProgressNodeManager(_context, gridSongs);
        }
    }
}
