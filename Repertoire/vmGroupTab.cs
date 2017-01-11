using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LiteDatabase;
using Repertoire.Annotations;

namespace Repertoire
{
    public class vmGroupTab:INotifyPropertyChanged
    {
        public Group Group { get; set; }
        public string Header { get; set; }

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
            Songs = Group == null ? 
                new ObservableCollection<Song>(ContextManager.Context.Songs.Where(x => !x.Groups.Any())) : 
                new ObservableCollection<Song>(ContextManager.Context.Songs.Where(x => x.Groups.Any(y => y.Name == Header)));
            Nodes = new ObservableCollection<ProgressNode>(ContextManager.Context.ProgressNodes);
        }

        public ObservableCollection<Song> Songs { get; private set; }
        public ObservableCollection<ProgressNode> Nodes { get; private set; } 

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
