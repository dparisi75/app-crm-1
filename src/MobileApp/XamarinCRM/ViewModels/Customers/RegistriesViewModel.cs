
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using XamarinCRM.Extensions;
using XamarinCRM.Statics;
using XamarinCRM.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinCRM.Models;
using XamarinCRM.Services;

namespace XamarinCRM.ViewModels.Customers
{
    public class RegistriesViewModel : BaseViewModel
    {
        ObservableCollection<Registry> _registries;
        public ObservableCollection<Registry> Registries
        {
            get { return _registries; }
            set
            {
                _registries = value;
                OnPropertyChanged("Registries");
            }
        }


        public RegistriesViewModel()
        {
            this.Title = "Registries";
            this.Icon = "list.png";

            
            Registries = new ObservableCollection<Registry>();
        }

        Command _LoadRegistriesCommand;

        /// <summary>
        /// Command to load Registries
        /// </summary>
        public Command LoadRegistriesCommand
        {
            get { return _LoadRegistriesCommand ?? (_LoadRegistriesCommand = new Command(async () => await ExecuteLoadRegistriesCommand())); }
        }

        async Task ExecuteLoadRegistriesCommand()
        {
            IsBusy = true;
            LoadRegistriesCommand.ChangeCanExecute();

            Registries = await LoadRegistries();

            IsBusy = false;
            LoadRegistriesCommand.ChangeCanExecute(); 
        }

        private Task<ObservableCollection<Registry>> LoadRegistries()
        {
            var registriesObservable = new ObservableCollection<Registry>();

            for (int i = 0; i < 1000; i++)
            {
                var registy = new Registry()
                {
                    Id = Faker.RandomNumber.Next(),
                    Name = Faker.Company.Name(),
                    Vat = Faker.Code.FiscalCode(),
                    Address = Faker.Address.StreetAddress()
                };
                registriesObservable.Add(registy);
            }
            var task = Task<ObservableCollection<Registry>>.Factory.StartNew(() =>
             registriesObservable);
            return task;
        }
         
        Command _LoadRegistriesRemoteCommand;

        public Command LoadRegistriesRefreshCommand
        {
            get { return _LoadRegistriesRemoteCommand ?? (_LoadRegistriesRemoteCommand = new Command(async () => await ExecuteLoadRegistriesRefreshCommand())); }
        }

        async Task ExecuteLoadRegistriesRefreshCommand()
        {
            IsBusy = true;
            LoadRegistriesRefreshCommand.ChangeCanExecute();       

            Registries = await LoadRegistries();

            IsBusy = false;
            LoadRegistriesRefreshCommand.ChangeCanExecute(); 
        }

        public static readonly Position NullPosition = new Position(0, 0);

        public List<Pin> LoadPins()
        {
            //var pins = Registries.Select(model =>
            //    {
            //        var item = model;
            //        var address = item.AddressString;

            //        var position = address != null ? new Position(item.Latitude, item.Longitude) : NullPosition;
            //        var pin = new Pin
            //        {
            //            Type = PinType.Place,
            //            Position = position,
            //            Label = item.ToString(),
            //            Address = address?.ToString()
            //        };
            //        return pin;
            //    }).ToList();

            //return pins; 
            return null;
        }
    }
}