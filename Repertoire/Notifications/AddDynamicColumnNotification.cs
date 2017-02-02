using LiteDatabase;
using Repertoire.InteractionRequest;

namespace Repertoire.Notifications
{
    public class AddDynamicColumnNotification : Notification
    {
        public ProgressNode Node { get; set; }
    }
}