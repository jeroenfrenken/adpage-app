using AdPage.UITests.Pages;
using NUnit.Framework;
using Xamarin.UITest;

namespace AdPage.UITests.Tests
{
    public class LoginTest: BaseTest
    {
        
        public LoginTest(Platform platform) : base(platform)
        {
        }

        public override void BeforeEachTest()
        {
            base.BeforeEachTest();
            LoginPage.WaitForPageToLoad();
        }

        [Test]
        public void LoginSuccessTest()
        {

            var email = "jeroenfrenken@icloud.com";
            var password = "Fastpages12";
            
            LoginPage.EnterEmail(email);
            LoginPage.EnterPassword(password);
            LoginPage.OnLoginTapped();
            
            
            


        }
        
        
    }
}