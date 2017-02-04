using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace LiteDatabase
{
    public static class ContextManager
    {
        private static EntityModel _context;
        public static EntityModel Context => _context ?? (_context = new EntityModel());

        private static ObservableCollection<Status> _statuses = new ObservableCollection<Status>(Context.Statuses);
        public static ObservableCollection<Status> Statuses
            => _statuses ?? (_statuses = new ObservableCollection<Status>(Context.Statuses));

        private static ObservableCollection<Artist> _artists = new ObservableCollection<Artist>(Context.Artists);
        public static ObservableCollection<Artist> Artists
            => _artists ?? (_artists = new ObservableCollection<Artist>(Context.Artists));

        private static ObservableCollection<ProgressNode> _nodes;
        public static ObservableCollection<ProgressNode> Nodes
            => _nodes ?? (_nodes = new ObservableCollection<ProgressNode>(_context.ProgressNodes));

        public static void AddNodeToSong(string argNode, string argSong, string argGroup = "")
        {
            // If such relationship already present throw Exception
            if (Context.Songs.Any(
                x =>
                    x.Title == argSong &&
                    x.Groups.Any(y => y.Name == argGroup) &&
                    x.rProgressNodeSongs.Any(y => y.ProgressNode.Name == argNode)))
                throw new Exception("Trying to add existing relationship");

            var node = Context.ProgressNodes.First(x => x.Name == argNode);
            var group = Context.Groups.First(x => x.Name == argGroup);
            var song = Context.Songs.First(
                x =>
                    x.Title == argSong &&
                    x.Groups.Any(y => y.Name == argGroup));

            song.rProgressNodeSongs.Add(new rProgressNodeSong
            {
                Song = song,
                ProgressNode = node,
                Group = group
            });

            Context.SaveChanges();
        }

        public static void RemoveNodeFromSong(string argNode, string argSong, string argGroup)
        {
            if (!Context.Songs.Any(
                x =>
                    x.Title == argSong &&
                    x.Groups.Any(y => y.Name == argGroup) &&
                    x.rProgressNodeSongs.Any(y => y.ProgressNode.Name == argNode)))
                throw new Exception("Trying to remove non-existant relationship");

            var song = Context.Songs.First(
                x =>
                    x.Title == argSong &&
                    x.Groups.Any(y => y.Name == argGroup));

            var progressNodeSong =
                song.rProgressNodeSongs.First(x => x.ProgressNode.Name == argNode && x.Song.Title == argSong);

            song.rProgressNodeSongs.Remove(progressNodeSong);

            Context.SaveChanges();
        }
    }
}