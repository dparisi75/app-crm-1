using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XamarinCRM.Pages
{
    public class GroupMenuItem
    {
        public GroupMenuItem()
        {
            MenuType = GroupMenuType.All;
        }

        //public string Icon { get; set; }

        public GroupMenuType MenuType { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public int Id { get; set; }

        public Color Color { get; set; }
    }

    public class GroupedGroupMenuItem : ObservableCollection<GroupMenuItem>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
    }
}