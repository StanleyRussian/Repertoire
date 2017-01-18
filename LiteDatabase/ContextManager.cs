using System.Collections.ObjectModel;

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
    }
}