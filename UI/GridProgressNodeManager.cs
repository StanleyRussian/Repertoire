using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using LiteDatabase;
using Repertoire;

namespace UI
{
    public static class GridProgressNodeManager
    {
        private static DataGrid grid;

        public static void Initialize(DataGrid argGrid)
        {
            grid = argGrid;
            foreach (var node in ContextManager.Nodes)
                NodeInitialized(node);
        }

        public static void NodeAdded(ProgressNode argNode)
        {
            var resourceDictionary = ResourceDictionaryResolver.GetResourceDictionary("Styles.xaml");
            var userRoleValueConverter = resourceDictionary["SongNodeValueConverter"] as IValueConverter;
            var checkBoxColumnStyle = resourceDictionary["MetroDataGridCheckBox"] as Style;

            var binding = new Binding
            {
                Converter = userRoleValueConverter,
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof (DataGridCell), 1),
                Path = new PropertyPath("."),
                Mode = BindingMode.TwoWay
            };

            var checkBoxColumn = new DataGridCheckBoxColumn
            {
                Header = argNode.Name,
                Width = 75,
                Binding = binding,
                ElementStyle = checkBoxColumnStyle
            };

            tagNode.SetTag(checkBoxColumn, argNode.Name);
            //tagGroup.SetTag(checkBoxColumn, a.Group.Name);
            grid.Columns.Add(checkBoxColumn);
        }

        public static void NodeChanged()
        {
            throw new System.NotImplementedException();
        }

        public static void NodeDeleted()
        {
            throw new System.NotImplementedException();
        }

        public static void NodeInitialized(ProgressNode argNode)
        {
            if (grid.Columns.All(x => (string) x.Header != argNode.Name))
                NodeAdded(argNode);
        }
    }
}
