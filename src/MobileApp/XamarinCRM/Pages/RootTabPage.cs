using Xamarin.Forms;
using XamarinCRM.Pages.About;
using XamarinCRM.Pages.Customers;
using XamarinCRM.Pages.Products;
using XamarinCRM.Pages.Sales;
using XamarinCRM.ViewModels;
using XamarinCRM.ViewModels.Customers;
using XamarinCRM.ViewModels.Products;

namespace XamarinCRM.Pages
{
    public class RootTabPage : TabbedPage
    {
        public RootTabPage()
        {
            Children.Add(new CRMNavigationPage(new SalesDashboardPage
            { 
                Title = TextResources.MainTabs_Sales, 
                Icon = new FileImageSource { File = "sales.png" }
            })
            { 
                Title = TextResources.MainTabs_Sales, 
                Icon = new FileImageSource { File = "sales.png" }
            });
            Children.Add(new CRMNavigationPage(new CustomersPage
            { 
                BindingContext = new CustomersViewModel() { Navigation = this.Navigation }, 
                Title = TextResources.MainTabs_Customers, 
                Icon = new FileImageSource { File = "customers.png" } 
            })
            {  
                Title = TextResources.MainTabs_Customers, 
                Icon = new FileImageSource { File = "customers.png" } 
            });
            Children.Add(new CRMNavigationPage(new CategoryListPage
            { 
                BindingContext = new CategoriesViewModel() { Navigation = this.Navigation }, 
                Title = TextResources.MainTabs_Products, 
                Icon = new FileImageSource { File = "products.png" } 
            })
            { 
                Title = TextResources.MainTabs_Products, 
                Icon = new FileImageSource { File = "products.png" },
            });
            Children.Add(new CRMNavigationPage(new AboutItemListPage
            { 
                Title = TextResources.MainTabs_About, 
                Icon = new FileImageSource { File = "about.png" },
                BindingContext = new AboutItemListViewModel() { Navigation = this.Navigation }
            })
            { 
                Title = TextResources.MainTabs_About, 
                Icon = new FileImageSource { File = "about.png" } 
            });
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            this.Title = this.CurrentPage.Title;
        }
    }
}