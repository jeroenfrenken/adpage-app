using System.ComponentModel;
using AdPage.Interfaces;
using AdPage.ViewModels;
using Xamarin.Forms;

namespace AdPage.Views
{
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        private bool _checked = false;
        
        private MainPageViewModel _viewModel;
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MainPageViewModel();
        }

        /**
         * Checks if a token that is in localstorage is still valid.
         *
         * Else it will launch the login page
         */
        private async void CheckAccountToken()
        {
            var hud = DependencyService.Get<IHud>();
            hud.Show ("Loading Account");

            var res = await _viewModel.CheckIfTokenValid();

            hud.Dismiss();
            if (!res)
            {
                await Navigation.PushModalAsync(new LoginPage());
            }
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!_checked)
            {
                _checked = true;
                CheckAccountToken();    
            }
            
        }
    }
}