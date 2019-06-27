using System;
using AdPage.Droid;
using AdPage.Interfaces;
using AndroidHUD;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(Hud))]
namespace AdPage.Droid
{
    public class Hud : IHud
    {

        public void Show(string message) 
        {
            Device.BeginInvokeOnMainThread (() =>
            {
                AndHUD.Shared.Show(Application.Context, "Status Message", (int) MaskType.Clear);
            });
        }

        public void Error(string message)
        {
            Device.BeginInvokeOnMainThread (() =>
            {
                AndHUD.Shared.ShowError(Application.Context, message, MaskType.Clear, TimeSpan.FromSeconds(1.2));
            });   
        }

        public void Success(string message)
        {
            Device.BeginInvokeOnMainThread (() =>
            {
                AndHUD.Shared.ShowSuccess(Application.Context, message, MaskType.Clear, TimeSpan.FromSeconds(1.2));
            });
        }

        public void Dismiss() 
        {
            Device.BeginInvokeOnMainThread (() =>
            {
                AndHUD.Shared.Dismiss(Application.Context);
            });
        }
    }
}