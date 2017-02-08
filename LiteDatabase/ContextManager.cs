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

        public static void AddNewNode(ProgressNode argNode)
        {
            Context.ProgressNodes.Add(argNode);
            Context.SaveChanges();
        }

        public static void AddNodeToSong(string argNode, string argSong, string argGroup = "")
        {
            // Due to behaviour of WPF this check is needed
            if (Context.RProgressNodeSongs.Any(x => 
                    x.Group.Name == argGroup && 
                    x.ProgressNode.Name == argNode && 
                    x.Song.Title == argSong))
                return;

            var node = Context.ProgressNodes.First(x => x.Name == argNode);
            var group = Context.Groups.FirstOrDefault(x => x.Name == argGroup);
            var song = Context.Songs.First(x => x.Title == argSong);

            // [group] will be null due to [argGroup] being empty when songs without groups are selected
            if (group != null)
                song.rProgressNodeSongs.Add(new rProgressNodeSong
                {
                    Song = song,
                    ProgressNode = node,
                    Group = group
                });
            else
                song.rProgressNodeSongs.Add(new rProgressNodeSong
                {
                    Song = song,
                    ProgressNode = node,
                });

            Context.SaveChanges();
        }

        public static void RemoveNodeFromSong(string argNode, string argSong, string argGroup)
        {
            // Due to behaviour of WPF this check is needed
            if (!Context.RProgressNodeSongs.Any(x =>
                    x.Group.Name == argGroup &&
                    x.ProgressNode.Name == argNode &&
                    x.Song.Title == argSong))
                return;

            var group = Context.Groups.FirstOrDefault(x => x.Name == argGroup);

            // [group] will be null due to [argGroup] being empty when songs without groups are selected
            if (group != null)
            {
                var nodeSong = Context.RProgressNodeSongs.First(x => 
                    x.Song.Title == argSong && 
                    x.ProgressNode.Name == argNode && 
                    x.Group.Name == argGroup);
                Context.RProgressNodeSongs.Remove(nodeSong);
            }
            else
            {
                var nodeSong = Context.RProgressNodeSongs.First(x =>
                    x.Song.Title == argSong &&
                    x.ProgressNode.Name == argNode &&
                    x.GroupId == null);
                Context.RProgressNodeSongs.Remove(nodeSong);
            }

            Context.SaveChanges();
        }
    }
}