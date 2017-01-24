using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using LiteDatabase;
using Repertoire.Annotations;

namespace Repertoire
{
    public class vmGroupTab:INotifyPropertyChanged
    {
        public Group Group { get; set; }
        public string Header { get; set; }

        public ObservableCollection<wrapSong> Songs { get; private set; }

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
            Songs = new ObservableCollection<wrapSong>();
            if (Group == null)
                foreach (var song in ContextManager.Context.Songs.Where(x => !x.Groups.Any()))
                    Songs.Add(new wrapSong(song));
            else
                foreach (var song in ContextManager.Context.Songs.Where(x => x.Groups.Any(y => y.Name == Header)))
                    Songs.Add(new wrapSong(song));

            //NodeAdded?.Invoke(this, new ProgressNodeEventArgs {Node = ContextManager.Nodes.First()});
        }

        public event EventHandler<ProgressNodeEventArgs> NodeAdded;
        public event EventHandler<ProgressNodeEventArgs> NodeInitialise;

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ProgressNodeEventArgs : EventArgs
    {
        public ProgressNode Node { get; set; }
    }
}