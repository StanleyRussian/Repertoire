using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
            var binding = new Binding
            {
                Converter = (IValueConverter) FindResource("SongNodeValueConverter"),
                RelativeSource =
                                      new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGridCell), 1),
                Path = new PropertyPath("."),
                Mode = BindingMode.TwoWay
            };

            var checkBoxColumn = new DataGridCheckBoxColumn
            {
                Header = e.Node.Name,
                Width = 75,
                Binding = binding,
                ElementStyle = (Style) FindResource("MetroDataGridCheckBox")
            };

            tagNode.SetTag(checkBoxColumn, e.Node.Name);
            tagGroup.SetTag(checkBoxColumn, _context.Group.Name);
            gridSongs.Columns.Add(checkBoxColumn);
        }


        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _context = DataContext as vmGroupTab;
            if (_context == null) return;

            _context.NodeAdded += _context_NodeAdded;

            //foreach (var node in ContextManager.Nodes)
            //    _context_NodeAdded(this, new ProgressNodeEventArgs { Node = node });
        }
    }
}
