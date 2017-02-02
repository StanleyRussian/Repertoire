using System;

namespace Repertoire.InteractionRequest
{
    public class InteractionRequest<T>
        where T : Notification
    {
        public event EventHandler<InteractionRequestedEventArgs> Raised;

        public void Raise(T context)
        {
            Raised?.Invoke(this, new InteractionRequestedEventArgs {Context = context});
        }
    }
}