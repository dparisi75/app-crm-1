using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCRM.Pages.Base;
using XamarinCRM.Services;
using XamarinCRM.Statics;
using XamarinCRM.ViewModels.Home;
using XamarinCRM.ViewModels.Splash;

namespace XamarinCRM.Pages.Home
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : LoginPageXaml
    {
        readonly IAuthenticationService _AuthenticationService;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
            _AuthenticationService = DependencyService.Get<IAuthenticationService>();


        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // fetch the demo credentials
            await ViewModel.LoadDemoCredentials();

            // pause for a moment before animations
            await Task.Delay(App.AnimationSpeed);
        }

        private void LogMeIn(object sender, EventArgs e)
        {
            _AuthenticationService.BypassAuthentication();

            // Broadcast a message that we have sucessdully authenticated.
            // This is mostly just for Android. We need to trigger Android to call the SalesDashboardPage.OnAppearing() method,
            // because unlike iOS, Android does not call the OnAppearing() method each time that the Page actually appears on screen.
            MessagingCenter.Send(this, MessagingServiceConstants.AUTHENTICATED);

            App.GoToRoot();
        }
    }

    class LoginPageViewModel : INotifyPropertyChanged
    {

        public LoginPageViewModel()
        {
            IncreaseCountCommand = new Command(IncreaseCount);
        }

        int count;

        string countDisplay = "You clicked 0 times.";
        public string CountDisplay
        {
            get { return countDisplay; }
            set { countDisplay = value; OnPropertyChanged(); }
        }

        public ICommand IncreaseCountCommand { get; }

        void IncreaseCount() =>
            CountDisplay = $"You clicked {++count} times";


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

    /// <summary>
    /// This class definition just gives us a way to reference ModelBoundContentPage<T> in the XAML of this Page.
    /// </summary>
    public abstract class LoginPageXaml : ModelBoundContentPage<LoginViewModel>
    {
    }
}
