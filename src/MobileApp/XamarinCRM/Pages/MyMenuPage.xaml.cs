
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinCRM.ViewModels.Base;
using Xamarin.Forms.Xaml;
using XamarinCRM.Pages.Customers;


namespace XamarinCRM.Pages
{
    public partial class MyMenuPage : ContentPage
    {
        MyRootPage root;
        List<HomeMenuItem> menuItems;
        private ObservableCollection<GroupedHomeMenuItem> grouped { get; set; }
        public MyMenuPage(MyRootPage root)
        {
            this.root = root;
            InitializeComponent();
            BindingContext = new BaseViewModel(Navigation)
                {
                    Title = "XamarinCRM",
                    Subtitle="XamarinCRM",
                    Icon = "slideout.png"
                };

            grouped = new ObservableCollection<GroupedHomeMenuItem>();

            var userGroup = new GroupedHomeMenuItem() { LongName = "User", ShortName = "U" };
            userGroup.Add(new HomeMenuItem { Title = "User", MenuType = MenuType.User, Icon = "about.png" });

            var anaGroup = new GroupedHomeMenuItem() { LongName = "Anagrafiche", ShortName = "A" };
            anaGroup.Add(new HomeMenuItem { Title = "Anagrafiche", MenuType = MenuType.Registries, Icon = "customers.png" });

            var docGroup = new GroupedHomeMenuItem() { LongName = "Gestione Documenti", ShortName = "D" };
            docGroup.Add(new HomeMenuItem { Title = "Gestione Documenti", MenuType = MenuType.Products, Icon = "products.png" });

            var markGroup = new GroupedHomeMenuItem() { LongName = "Marketing", ShortName = "M" };
            markGroup.Add(new HomeMenuItem { Title = "Marketing", MenuType = MenuType.About, Icon = "about.png" });

            grouped.Add(userGroup);
            grouped.Add(anaGroup);
            grouped.Add(docGroup);
            grouped.Add(markGroup);

            ListViewMenu.ItemsSource = grouped;

            //ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
            //    {
            //        new HomeMenuItem { Title = "User", MenuType = MenuType.User, Icon ="about.png" },
            //        new HomeMenuItem { Title = "Anagrafiche", MenuType = MenuType.Customers, Icon = "customers.png" },
            //        new HomeMenuItem { Title = "Gestione Documenti", MenuType = MenuType.Products, Icon = "products.png" },
            //        new HomeMenuItem { Title = "Marketing", MenuType = MenuType.About, Icon = "about.png" },

            //    };

            //ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.SelectedItem = grouped[1];

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
                    if (menuType == MenuType.Registries)
                    {
                        App.GoToRegistriesRoot();
                        return;
                    }
                  

                    await this.root.NavigateAsync(menuType);
                };
        }
    }
}

