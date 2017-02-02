using Repertoire.Notifications;
using UI.DependencyProperties;
using UI.InteractionRequest;
using UI.Views;

namespace UI.Actions
{
    public class DeleteDynamicColumnAction : TriggerActionBase<DeleteDynamicColumnNotification>
    {
        protected override void ExecuteAction()
        {
            var window = AssociatedObject as vGroupTab;
            if (window == null) return;

            foreach (var userRoleColumn in window.gridSongs.Columns)
            {
                var roleScan = tagNode.GetTag(userRoleColumn) as string;
                if (roleScan == Notification.Role.Name)
                    window.gridSongs.Columns.Remove(userRoleColumn);
            }
        }
    }
}