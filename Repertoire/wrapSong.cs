using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LiteDatabase;
using ViewModels.Auxiliary;

namespace Repertoire
{
    public class wrapSong
    {
        private Song _song;

        public wrapSong(Song song)
        {
            _song = song;
            cmdSetLastPlayedToday = new Command(cmdSetLastPlayedToday_Execute);
        }

        public string Title
        {
            get { return _song.Title; }
            set { _song.Title = value; }
        }

        public string LastPlayedDate
        {
            get { return _song.LastPlayedDate; }
            set { _song.LastPlayedDate = value; }
        }

        public Artist Artist
        {
            get { return _song.Artist; }
            set { _song.Artist = value; }
        }

        public Genre Genre
        {
            get { return _song.Genre; }
            set { _song.Genre = value; }
        }

        public Status Status
        {
            get { return _song.Status; }
            set { _song.Status = value; }
        }

        private ObservableCollection<Filepath> _filepaths;
        public ObservableCollection<Filepath> Filepaths
            => _filepaths ?? (_filepaths = new ObservableCollection<Filepath>(_song.Filepaths));

        private ObservableCollection<Group> _groups;
        public ObservableCollection<Group> Groups
            => _groups ?? (_groups = new ObservableCollection<Group>(_song.Groups));

        private ObservableCollection<wrapProgressNode> _progressNodes;
        //public ObservableCollection<wrapProgressNode> ProgressNodes
        //{
        //    get
        //    {
        //        if (_progressNodes.Count == 0)
        //        {
        //            foreach (var node in _song.ProgressNodes)
        //                _progressNodes.Add(new wrapProgressNode { Name = node.Name, Set = true });
        //            foreach (var node in ContextManager.Nodes)
        //            {
        //                if (_progressNodes.All(x => x.Name != node.Name))
        //                    _progressNodes.Add(new wrapProgressNode { Name = node.Name, Set = false });
        //            }
        //        }
        //        return _progressNodes;
        //    }
        //}

        public ICommand cmdSetLastPlayedToday { get; private set; }
        private void cmdSetLastPlayedToday_Execute(object argSelected)
        {
            _song.LastPlayedDate = DateTime.Today.ToLongDateString();
        }
    }

    public class wrapProgressNode
    {
        public string Name { get; set; }
        public bool Set { get; set; }
    }
}
