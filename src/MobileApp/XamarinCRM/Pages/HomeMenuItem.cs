using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XamarinCRM.Pages
{
    public class HomeMenuItem
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.About;
        }

        public string Icon { get; set; }

        public MenuType MenuType { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public int Id { get; set; }
    }

    public class GroupedHomeMenuItem : ObservableCollection<HomeMenuItem>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
    }
}