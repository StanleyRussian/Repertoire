using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
