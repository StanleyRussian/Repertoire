using System.Windows.Controls;
using System.Windows.Data;
using Repertoire.Notifications;
using UI.InteractionRequest;
using UI.Views;

namespace UI.Actions
{
    public class AddTextColumnAction : TriggerActionBase<AddTextColumnNotification>
    {
        protected override void ExecuteAction()
        {
            var window = AssociatedObject as vGroupTab;
            window?.gridSongs.Columns.Add(
                new DataGridTextColumn
                {
                    Header = Notification.Header,
                    Binding = new Binding(Notification.Binding)
                });
        }
    }
}