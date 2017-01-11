using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDatabase
{
    public static class ContextManager
    {
        private static EntityModel _context;
        public static EntityModel Context => _context ?? (_context = new EntityModel());

        public static ObservableCollection<Status> Statuses => new ObservableCollection<Status>(Context.Statuses);
    }
}