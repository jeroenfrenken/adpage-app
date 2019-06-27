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
        
        MainPageViewModel viewModel;
        
        public MainPage()
        {
            InitializeComponent();
            
            BindingContext = viewModel = new MainPageViewModel();
        }

        async void PopupLogin()
        {
            var hud = DependencyService.Get<IHud>();
            hud.Show ("Loading Account");

            var res = await viewModel.CheckIfTokenValid();

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
                PopupLogin();    
            }
            
        }
    }
}