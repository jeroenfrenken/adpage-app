using System;
using AdPage.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        private UserViewModel _viewModel;

        public UserPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new UserViewModel();
        }

        private async void Logout(object sender, EventArgs args)
        {
            _viewModel.LogoutUser();
            await Navigation.PushModalAsync(new LoginPage());
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.UserCommand.Execute(null);
        }
    }
}