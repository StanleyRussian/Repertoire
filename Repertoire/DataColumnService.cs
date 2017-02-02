using Repertoire.InteractionRequest;
using Repertoire.Notifications;

namespace Repertoire
{
    public class DataColumnService
    {
        private static DataColumnService instance;

        private DataColumnService()
        {
            AddTextColumn = new InteractionRequest<AddTextColumnNotification>();
            AddDynamicColumn = new InteractionRequest<AddDynamicColumnNotification>();
            ChangeDynamicColumn = new InteractionRequest<ChangeDynamicColumnNotification>();
            DeleteDynamicColumn = new InteractionRequest<DeleteDynamicColumnNotification>();
        }

        public static DataColumnService Instance => instance ?? (instance = new DataColumnService());

        public InteractionRequest<AddTextColumnNotification> AddTextColumn { get; private set; }
        public InteractionRequest<AddDynamicColumnNotification> AddDynamicColumn { get; private set; }
        public InteractionRequest<ChangeDynamicColumnNotification> ChangeDynamicColumn { get; private set; }
        public InteractionRequest<DeleteDynamicColumnNotification> DeleteDynamicColumn { get; private set; }
    }
}