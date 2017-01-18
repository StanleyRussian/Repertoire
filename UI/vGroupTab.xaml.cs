using System;
using System.Windows;
using System.Windows.Controls;
using LiteDatabase;
using Repertoire;

namespace UI
{
    /// <summary>
    /// Interaction logic for vGroupTab.xaml
    /// </summary>
    public partial class vGroupTab
    {
        vmGroupTab _context;

        public vGroupTab()
        {
            InitializeComponent();
        }

        private void _context_NodeAdded(object sender, ProgressNodeEventArgs e)
        {
            gridSongs.Columns.Add(new DataGridCheckBoxColumn
            {
                Header = e.Node.Name,
                Width = 75,
                ElementStyle = (Style) FindResource("MetroDataGridCheckBox")
            });
        }


        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _context = DataContext as vmGroupTab;
            if (_context != null) _context.NodeAdded += _context_NodeAdded;

            foreach (var node in ContextManager.Nodes)
                _context_NodeAdded(this, new ProgressNodeEventArgs { Node = node });
        }
    }
}
