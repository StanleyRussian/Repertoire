using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using LiteDatabase;
using Repertoire.Auxiliary;

namespace Repertoire.ViewModels
{
    public class vmMainWindow
    {
        // This is crutch. But I can't think of any other way to implement it
        // It is needed for valueconverter to define which tab is selected at a time
        public static vmGroupTab SelectedTab { get { return Tabs.First(x => x.IsSelected); } }

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

            cmdOnClosing = new Command(cmdOnClosing_Execute);
        }

        public static ObservableCollection<vmGroupTab> Tabs { get; private set; }

        public ICommand cmdOnClosing { get; private set; }
        protected void cmdOnClosing_Execute()
        { }
    }
}