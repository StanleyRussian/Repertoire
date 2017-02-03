using System;

namespace Repertoire
{
    public interface iInvoke
    {
        event EventHandler<ProgressNodeEventArgs> NodeAdded;
        event EventHandler<ProgressNodeEventArgs> NodeInitialised;
        event EventHandler<ProgressNodeEventArgs> NodeChanged;
        event EventHandler<ProgressNodeEventArgs> NodeDeleted;

        void CallbackSubscribed();
    }
}
