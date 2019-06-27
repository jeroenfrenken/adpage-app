using System;
using System.ComponentModel;
using AdPage.Api.Client;
using AdPage.Interfaces;
using Xamarin.Forms;

namespace AdPage.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        private bool _checked = false;
        
        public MainPage()
        {
            InitializeComponent();
        }

        async void PopupLogin()
        {
            var hud = DependencyService.Get<IHud>();
            hud.Show ("Loading Account");
            try
            {
                var user = await ApiClient.Instance.GetUser();
                if (user.uuid == null)
                {
                    await Navigation.PushModalAsync(new LoginPage());
                }
            }
            catch (Exception e)
            {
                await Navigation.PushModalAsync(new LoginPage());
            }
            finally
            {
                hud.Dismiss();
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