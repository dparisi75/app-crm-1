using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinCRM.Pages.Customers;
using XamarinCRM.Pages.Home;
using XamarinCRM.Pages.Test;
using XamarinCRM.Statics;
using XamarinCRM.ViewModels.Base;

namespace XamarinCRM.ViewModels
{
    public class MyRegistriesRootViewModel : BaseViewModel
    {
        string _searchPlaceFilter = string.Empty;
        /// <summary>
        /// Gets or sets the "SearchPlaceFilter" property
        /// </summary>
        public const string SearchPlaceFilterPropertyName = "SearchPlaceFilter";

        public string SearchPlaceFilter
        {
            get { return _searchPlaceFilter; }
            set { SetProperty(ref _searchPlaceFilter, value, SearchPlaceFilterPropertyName); }
        }

        string _myPickerValue = string.Empty;
        /// <summary>
        /// Gets or sets the "MyPickerValue" property
        /// </summary>
        public const string MyPickerValuePropertyName = "MyPickerValue";

        public string MyPickerValue
        {
            get { return _myPickerValue; }
            set { SetProperty(ref _myPickerValue, value, MyPickerValuePropertyName); }
        }


        public MyRegistriesRootViewModel(INavigation navigation = null) : base(navigation)
        {
            MyPickerValue = "Nessuno";
            SetPlaceFilterCommand = new Command(SetPlaceFilter);

            MessagingCenter.Subscribe<SearchBarPlacesPage, string>(this, MessagingServiceConstants.PLACE_FILTER_SET, (s, e) => {
                SearchPlaceFilter = e;
            });
        }

        public ICommand SetPlaceFilterCommand { get; }

        async void SetPlaceFilter()
        {
            System.Diagnostics.Debug.WriteLine("SetPlaceFilterCommand");
            await Navigation.PushModalAsync(new SearchBarPlacesPage());
        }
    }
}
