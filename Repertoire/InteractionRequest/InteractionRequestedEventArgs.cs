using System;

namespace Repertoire.InteractionRequest
{
    public class InteractionRequestedEventArgs : EventArgs
    {
        public object Context { get; set; }
    }
}