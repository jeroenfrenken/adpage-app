using System;
using AdPage.Droid;
using AdPage.Interfaces;
using AndroidHUD;
using Xamarin.Forms;

[assembly: Dependency(typeof(Hud))]
namespace AdPage.Droid
{
    public class Hud : IHud
    {
        public void Show(string message) 
        {
            Device.BeginInvokeOnMainThread (() =>
            {
                AndHUD.Shared.Show(MainApplication.ActivityContext, message, (int) MaskType.Clear);
            });
        }

        public void Error(string message)
        {
            Device.BeginInvokeOnMainThread (() =>
            {
                AndHUD.Shared.ShowError(MainApplication.ActivityContext, message, MaskType.Clear, TimeSpan.FromSeconds(1.2));
            });   
        }

        public void Success(string message)
        {
            Device.BeginInvokeOnMainThread (() =>
            {
                AndHUD.Shared.ShowSuccess(MainApplication.ActivityContext, message, MaskType.Clear, TimeSpan.FromSeconds(1.2));
            });
        }

        public void Dismiss() 
        {
            Device.BeginInvokeOnMainThread (() =>
            {
                AndHUD.Shared.Dismiss(MainApplication.ActivityContext);
            });
        }
    }
}