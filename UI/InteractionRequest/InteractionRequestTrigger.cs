using System.Windows.Interactivity;

namespace UI.InteractionRequest
{
    public class InteractionRequestTrigger : EventTrigger
    {
        protected override string GetEventName()
        {
            return "Raised";
        }
    }
}