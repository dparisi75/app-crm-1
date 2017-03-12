
using Xamarin.Forms;
using XamarinCRM.Pages.Customers;
using XamarinCRM.Pages.Products;
using XamarinCRM.Pages.Sales;
using XamarinCRM.Pages.Splash;
using XamarinCRM.ViewModels.Customers;
using XamarinCRM.ViewModels.Splash;
using XamarinCRM.Services;
using XamarinCRM.ViewModels.Products;
using System.Threading.Tasks;
using XamarinCRM.ViewModels.Base;
using System.Collections.Generic;
using XamarinCRM.Pages.About;
using XamarinCRM.ViewModels;

namespace XamarinCRM.Pages
{


    public class MyRootPage : MasterDetailPage
    {
        Dictionary<MenuType, NavigationPage> Pages { get; set; }

        public MyRootPage()
        {
            Pages = new Dictionary<MenuType, NavigationPage>();
            Master = new MyMenuPage(this);
            BindingContext = new BaseViewModel(Navigation)
            {
                Title = "Xamarin CRM",
                Icon = "slideout.png"
            };
            //setup home page
            NavigateAsync(MenuType.Customers);
        }

        void SetDetailIfNull(Page page)
        {
            if (Detail == null && page != null)
                Detail = page;
        }

        public async Task NavigateAsync(MenuType id)
        {
            Page newPage;
            if (!Pages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuType.Sales:
                        var page = new CRMNavigationPage(new SalesDashboardPage
                            { 
                                Title = TextResources.MainTabs_Sales, 
                                Icon = new FileImageSource { File = "sales.png" }
                            });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                    case MenuType.Customers:
                        page = new CRMNavigationPage(new CustomersPage
                            { 
                                BindingContext = new CustomersViewModel() { Navigation = this.Navigation }, 
                                Title = TextResources.MainTabs_Customers, 
                                Icon = new FileImageSource { File = "customers.png" } 
                            });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                    case MenuType.Products:
                        page = new CRMNavigationPage(new CategoryListPage
                            { 
                                BindingContext = new CategoriesViewModel() { Navigation = this.Navigation }, 
                                Title = TextResources.MainTabs_Products, 
                                Icon = new FileImageSource { File = "products.png" } 
                            });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                    case MenuType.About:
                        page = new CRMNavigationPage(new AboutItemListPage
                            { 
                                Title = TextResources.MainTabs_Products, 
                                Icon = new FileImageSource { File = "about.png" },
                                BindingContext = new AboutItemListViewModel() { Navigation = this.Navigation }
                            });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                }
            }

            newPage = Pages[id];
            if (newPage == null)
                return;

            //pop to root for Windows Phone
            if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            {
                await Detail.Navigation.PopToRootAsync();
            }

            Detail = newPage;

            if (Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }
    }

    /*public class RootPage : TabbedPage
    {
        

        public RootPage()
        {
            
            // the Sales tab page
            this.Children.Add(
                new NavigationPage(new SalesDashboardPage())
                { 
                    Title = TextResources.MainTabs_Sales, 
                    Icon = new FileImageSource() { File = "SalesTab" }
                }
            );

            // the Customers tab page
            this.Children.Add(
                new CustomersPage()
                { 
                    BindingContext = new CustomersViewModel(Navigation), 
                    Title = TextResources.MainTabs_Customers, 
                    Icon = new FileImageSource() { File = "CustomersTab" } 
                }
            );

            // the Products tab page
            this.Children.Add(
                new NavigationPage(new CategoryListPage() { BindingContext = new CategoriesViewModel() } )
                { 
                    Title = TextResources.MainTabs_Products, 
                    Icon = new FileImageSource() { File = "ProductsTab" } 
                }
            );
        }
    }*/
}

