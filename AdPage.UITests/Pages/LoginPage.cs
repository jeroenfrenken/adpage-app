using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace AdPage.UITests.Pages
{
    public class LoginPage: BasePage
    {
        
        readonly Query emailInput, passwordInput, loginButton;
        
        public LoginPage(IApp app, Platform platform) : base(app, platform, "Login")
        {

            if (OniOS)
            {
                emailInput = x => x.Id("LoginPageEmail");
                passwordInput = x => x.Id("LoginPagePassword");
            }
            else
            {
                emailInput = x => x.Id("LoginPageEmail");
                passwordInput = x => x.Id("LoginPagePassword");
            }
            
            loginButton = x => x.Marked("LOGIN");
        }

        public void EnterEmail(string email)
        {
            EnterText(emailInput, email);
            app.Screenshot("Entered Email");
        }

        public void EnterPassword(string password)
        {
            EnterText(passwordInput, password);
            app.Screenshot("Entered Password");
        }

        public void OnLoginTapped()
        {
            app.Tap(loginButton);
            app.Screenshot("Login Tapped");
        }
        
        
        
    }
}