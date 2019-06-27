using AdPage.Interfaces;
using AdPage.iOS;
using BigTed;
using Xamarin.Forms;

[assembly: Dependency(typeof(Hud))]
namespace AdPage.iOS
{
    public class Hud : IHud
    {

        public void Show(string message) 
        {
            BTProgressHUD.Show(
                message,
                -1f,
                ProgressHUD.MaskType.Black
            );
        }

        public void Error(string message)
        {
            BTProgressHUD.ShowErrorWithStatus(
                message,
                1200
            );    
        }

        public void Success(string message)
        {
            BTProgressHUD.ShowSuccessWithStatus(
                message,
                1200
            );
        }

        public void Dismiss() 
        {
            BTProgressHUD.Dismiss();
        }
    }
}