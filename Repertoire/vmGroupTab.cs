using System;
using System.Collections.ObjectModel;
using System.Linq;
using LiteDatabase;

namespace Repertoire
{
    public class vmGroupTab: iInvoke
    {
        public Group Group { get; set; }
        public string Header { get; set; }

        public ObservableCollection<Song> Songs { get; private set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                if (_isSelected)
                    Load();
            }
        }

        private void Load()
        {
            // If [Group] property is null - it fills [Songs] collection with songs whch does not contained in any group
            // Otherwise it look for songs which contained in group with the name same as [Group]
            Songs = new ObservableCollection<Song>();
            Songs = Group == null
                ? new ObservableCollection<Song>(ContextManager.Context.Songs.Where(x => !x.Groups.Any()))
                : new ObservableCollection<Song>(ContextManager.Context.Songs.Where(x => x.Groups.Any(y => y.Name == Group.Name)));

            foreach (var node in ContextManager.Nodes)
                NodeInitialised?.Invoke(this, new ProgressNodeEventArgs {Node = node});
        }

        public event EventHandler<ProgressNodeEventArgs> NodeAdded;
        public event EventHandler<ProgressNodeEventArgs> NodeInitialised;
        public event EventHandler<ProgressNodeEventArgs> NodeChanged;
        public event EventHandler<ProgressNodeEventArgs> NodeDeleted;
    }

    public class ProgressNodeEventArgs : EventArgs
    {
        public ProgressNode Node { get; set; }
    }
}