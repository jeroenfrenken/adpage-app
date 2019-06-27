using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdPage.Interfaces;
using AdPage.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;
        
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginViewModel();
        }

        public async void OnSubmit(object sender, EventArgs args)
        {
            var hud = DependencyService.Get<IHud>();
            hud.Show("Loading...");
            var res = await viewModel.Login();
            if (res)
            {
                await Navigation.PopModalAsync();
                hud.Success("Logged in");
            }
            else
            {
                hud.Error("Wrong credentials");
            }
        }
        
    }
}