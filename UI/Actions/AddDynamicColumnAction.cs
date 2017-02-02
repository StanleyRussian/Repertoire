using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Repertoire.Notifications;
using UI.Auxiliary;
using UI.DependencyProperties;
using UI.InteractionRequest;
using UI.Views;

namespace UI.Actions
{
    public class AddDynamicColumnAction : TriggerActionBase<AddDynamicColumnNotification>
    {
        protected override void ExecuteAction()
        {
            var window = AssociatedObject as vGroupTab;
            if (window == null || 
                window.gridSongs.Columns.Any(x => (string) x.Header == Notification.Node.Name))
                return;

            //var resourceDictionary = ResourceDictionaryResolver.GetResourceDictionary("App.xaml");
            //var userRoleValueConverter = resourceDictionary["SongNodeValueConverter"] as IValueConverter;
            //var checkBoxColumnStyle = resourceDictionary["MetroCheckBoxColumnStyle"] as Style;

            var binding = new Binding
            {
                //Converter = userRoleValueConverter,
                //RelativeSource =
                //    new RelativeSource(RelativeSourceMode.FindAncestor, typeof (DataGridCell), 1),
                //Path = new PropertyPath("."),
                //Mode = BindingMode.TwoWay
            };

            var dataGridCheckBoxColumn = new DataGridCheckBoxColumn
            {
                Header = Notification.Node.Name,
                //Binding = binding,
                IsThreeState = false,
                CanUserSort = false,
                /*ElementStyle = checkBoxColumnStyle*/
            };

            tagNode.SetTag(dataGridCheckBoxColumn, Notification.Node.Name);

            window.gridSongs.Columns.Add(dataGridCheckBoxColumn);
        }
    }
}