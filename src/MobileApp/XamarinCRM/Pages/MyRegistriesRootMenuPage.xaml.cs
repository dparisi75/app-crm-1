
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinCRM.ViewModels.Base;
using Xamarin.Forms.Xaml;
using XamarinCRM.Pages.Customers;
using XamarinCRM.ViewModels;


namespace XamarinCRM.Pages
{
    public partial class MyRegistriesRootMenuPage : ContentPage
    {
        MyRegistriesRootPage root;
        List<HomeMenuItem> menuItems;
        private ObservableCollection<GroupedGroupMenuItem> grouped { get; set; }
        public MyRegistriesRootMenuPage(MyRegistriesRootPage root)
        {
            this.root = root;
            InitializeComponent();
            BindingContext = new MyRegistriesRootViewModel(Navigation)
                {
                    Title = "XamarinCRM",
                    Subtitle="XamarinCRM",
                    Icon = "slideout.png"
                };
            //ListViewMenu.BindingContext = BindingContext;

            grouped = new ObservableCollection<GroupedGroupMenuItem>();

            var groupGroup = new GroupedGroupMenuItem() { LongName = "Gruppi", ShortName = "G" };
            groupGroup.Add(new GroupMenuItem { Title = "Tutti", MenuType = GroupMenuType.All, Color = Color.Blue});
            groupGroup.Add(new GroupMenuItem { Title = "Bronze", MenuType = GroupMenuType.Bronze, Color = Color.Yellow });
            groupGroup.Add(new GroupMenuItem { Title = "Silver", MenuType = GroupMenuType.Silver, Color = Color.Silver });
            groupGroup.Add(new GroupMenuItem { Title = "Gold", MenuType = GroupMenuType.Gold, Color = Color.Olive });

            //var placeGroup = new GroupedGroupMenuItem() { LongName = "Località", ShortName = "A" };
            //placeGroup.Add(new GroupMenuItem { Title = "Anagrafiche", MenuType = MenuType.Customers, Icon = "customers.png" });
         

            grouped.Add(groupGroup);
            //grouped.Add(placeGroup);

            ListViewMenu.ItemsSource = grouped;

            //ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
            //    {
            //        new HomeMenuItem { Title = "User", MenuType = MenuType.User, Icon ="about.png" },
            //        new HomeMenuItem { Title = "Anagrafiche", MenuType = MenuType.Customers, Icon = "customers.png" },
            //        new HomeMenuItem { Title = "Gestione Documenti", MenuType = MenuType.Products, Icon = "products.png" },
            //        new HomeMenuItem { Title = "Marketing", MenuType = MenuType.About, Icon = "about.png" },

            //    };

            //ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.SelectedItem = grouped[0];

            ListViewMenu.ItemSelected += async (sender, e) => 
                {
                    if(ListViewMenu.SelectedItem == null)
                        return;
                    var menuType = ((HomeMenuItem) e.SelectedItem).MenuType;
                    if (menuType ==  MenuType.User)
                    {
                        await this.root.DisplayAlert("Attenzione", "Vuoi effettuare il logout?", "OK", "Annulla");
                        App.GoToRoot();
                        return;
                    }
                    if (menuType == MenuType.About)
                    {
                        await App.CurrentApp.MainPage.Navigation.PushAsync(new CRMNavigationPage(new CustomerDetailPage()));
                    }
                  

                    await this.root.NavigateAsync(menuType);
                };

            
        }
    }
}

