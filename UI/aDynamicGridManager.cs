using System.Linq;
using System.Windows.Controls;
using Repertoire;

namespace UI
{
    public abstract class aDynamicGridManager
    {
        protected iInvoke context;
        protected DataGrid grid;

        protected abstract void NodeAdded(object sender, ProgressNodeEventArgs e);
        protected abstract void NodeChanged(object sender, ProgressNodeEventArgs e);
        protected abstract void NodeDeleted(object sender, ProgressNodeEventArgs e);
        protected virtual void NodeInitialized(object sender, ProgressNodeEventArgs e)
        {
            if (grid.Columns.All(x => (string) x.Header != e.Node.Name))
                NodeAdded(sender, e);
        }

        protected aDynamicGridManager(iInvoke argContext, DataGrid argGrid)
        {
            context = argContext;
            grid = argGrid;

            context.NodeAdded += NodeAdded;
            context.NodeChanged += NodeChanged;
            context.NodeDeleted += NodeDeleted;
            context.NodeInitialised += NodeInitialized;
        }
    }
}