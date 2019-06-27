using System;
using AdPage.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        UserViewModel viewModel;

        public UserPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
        }

        async void Logout(object sender, EventArgs args)
        {
            viewModel.LogoutUser();
            await Navigation.PushModalAsync(new LoginPage());
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.UserCommand.Execute(null);
        }
    }
}