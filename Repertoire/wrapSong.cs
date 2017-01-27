using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LiteDatabase;
using Repertoire.Auxiliary;

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

        public ICommand cmdSetLastPlayedToday { get; private set; }
        private void cmdSetLastPlayedToday_Execute(object argSelected)
        {
            _song.LastPlayedDate = DateTime.Today.ToLongDateString();
        }
    }
}
