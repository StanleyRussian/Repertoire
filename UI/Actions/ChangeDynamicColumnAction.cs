using Repertoire.Notifications;
using UI.DependencyProperties;
using UI.InteractionRequest;
using UI.Views;

namespace UI.Actions
{
    public class ChangeDynamicColumnAction : TriggerActionBase<ChangeDynamicColumnNotification>
    {
        protected override void ExecuteAction()
        {
            var window = AssociatedObject as vGroupTab;
            if (window == null) return;

            foreach (var userRoleColumn in window.gridSongs.Columns)
            {
                var roleScan = tagNode.GetTag(userRoleColumn) as string;
                if (roleScan == Notification.Role.Name && Notification.Role != null)
                    userRoleColumn.Header = Notification.Role.Name;
            }
        }
    }
}