using System.Windows;
using System.Windows.Interactivity;
using Repertoire.InteractionRequest;

namespace UI.InteractionRequest
{
    public abstract class TriggerActionBase<T> : TriggerAction<FrameworkElement> where T : Notification
    {
        protected T Notification { get; set; }

        protected override void Invoke(object parameter)
        {
            var interactionRequestedEventArgs = parameter as InteractionRequestedEventArgs;
            if (interactionRequestedEventArgs != null) Notification = interactionRequestedEventArgs.Context as T;
            ExecuteAction();
        }

        protected abstract void ExecuteAction();
    }
}