using LiteDatabase;
using Repertoire.InteractionRequest;

namespace Repertoire.Notifications
{
    public class DeleteDynamicColumnNotification : Notification
    {
        public ProgressNode Role { get; set; }
    }
}