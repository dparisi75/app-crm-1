using Xamarin.Forms;
using XamarinCRM.Statics;

namespace XamarinCRM.Pages
{
    public class CRMNavigationPage :NavigationPage
    {
        public CRMNavigationPage(Page root)
            : base(root)
        {
            Init();
        }

        public CRMNavigationPage()
        {
            Init();
        }

        void Init()
        {

            BarBackgroundColor = Palette._001;
            BarTextColor = Color.White;
        }
    }
}