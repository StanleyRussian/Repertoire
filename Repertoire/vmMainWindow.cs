using System.Collections.ObjectModel;
using System.Windows.Input;
using LiteDatabase;

namespace Repertoire
{
    public class vmMainWindow
    {
        public vmMainWindow()
        {
            Tabs = new ObservableCollection<vmGroupTab>();
            foreach (var group in ContextManager.Context.Groups)
            {
                Tabs.Add(new vmGroupTab
                {
                    Group = group,
                    Header = group.Name
                });
            }
            Tabs.Add(new vmGroupTab
            {
                Group = null,
                Header = "Without group"
            });
        }

        public ObservableCollection<vmGroupTab> Tabs { get; private set; }

        public ICommand cmdOnClosing { get; private set; }
        protected void cmdOnClosing_Execute()
        {
            ContextManager.Context.SaveChanges();
        }
    }
}
