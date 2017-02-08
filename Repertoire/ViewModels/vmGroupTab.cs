using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DynamicGridManagers;
using LiteDatabase;
using MahApps.Metro.Controls.Dialogs;
using Repertoire.Auxiliary;

namespace Repertoire.ViewModels
{
    public class vmGroupTab
    {
        public vmGroupTab()
        {
            cmdNewProgressNode = new Command(cmdNewProgressNode_Execute);
        }

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

        public ICommand cmdNewProgressNode { get; }
        private async void cmdNewProgressNode_Execute()
        {
            var newNodeName = await DialogCoordinator.Instance.ShowInputAsync(this, "Creating progress node", "Type a name for a new node");
            if (newNodeName == null) return;
            var node = new ProgressNode {Name = newNodeName};
            ContextManager.AddNewNode(node);
            GridProgressNodeManager.NodeAdded(node);
        }

        private void Load()
        {
            // If [Group] property is null - it fills [Songs] collection with songs whch does not contained in any group
            // Otherwise it look for songs which contained in group with the name same as [Group]
            Songs = new ObservableCollection<Song>();
            Songs = Group == null
                ? new ObservableCollection<Song>(ContextManager.Context.Songs.Where(x => !x.Groups.Any()))
                : new ObservableCollection<Song>(ContextManager.Context.Songs.Where(x => x.Groups.Any(y => y.Name == Group.Name)));
        }
    }
}