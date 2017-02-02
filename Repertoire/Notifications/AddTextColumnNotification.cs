using Repertoire.InteractionRequest;

namespace Repertoire.Notifications
{
    public class AddTextColumnNotification : Notification
    {
        public string Header { get; set; }
        public string Binding { get; set; }
    }
}