using LiteDatabase;
using Repertoire.InteractionRequest;

namespace Repertoire.Notifications
{
    public class ChangeDynamicColumnNotification : Notification
    {
        public ProgressNode Role { get; set; }
    }
}