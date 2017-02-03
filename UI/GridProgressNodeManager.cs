using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Repertoire;

namespace UI
{
    public class GridProgressNodeManager: aDynamicGridManager
    {
        protected string groupName;

        public GridProgressNodeManager(iInvoke argContext, DataGrid argGrid)
            :base(argContext, argGrid)
        {
            var tab = argContext as vmGroupTab;
            groupName = tab.Group.Name;

            context.CallbackSubscribed();
        }

        protected override void NodeAdded(object sender, ProgressNodeEventArgs e)
        {
            var resourceDictionary = ResourceDictionaryResolver.GetResourceDictionary("Styles.xaml");
            var userRoleValueConverter = resourceDictionary["SongNodeValueConverter"] as IValueConverter;
            var checkBoxColumnStyle = resourceDictionary["MetroDataGridCheckBox"] as Style;

            var binding = new Binding
            {
                Converter = userRoleValueConverter,
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGridCell), 1),
                Path = new PropertyPath("."),
                Mode = BindingMode.TwoWay
            };

            var checkBoxColumn = new DataGridCheckBoxColumn
            {
                Header = e.Node.Name,
                Width = 75,
                Binding = binding,
                ElementStyle = checkBoxColumnStyle
            };

            // !! TEMPORARY !!
            var a = sender as vmGroupTab;

            tagNode.SetTag(checkBoxColumn, e.Node.Name);
            tagGroup.SetTag(checkBoxColumn, a.Group.Name);
            grid.Columns.Add(checkBoxColumn);
        }

        protected override void NodeChanged(object sender, ProgressNodeEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected override void NodeDeleted(object sender, ProgressNodeEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
