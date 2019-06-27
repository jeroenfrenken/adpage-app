using AdPage.UITests.Pages;
using NUnit.Framework;
using Xamarin.UITest;

namespace AdPage.UITests.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]

    public abstract class BaseTest
    {
        protected IApp app;
        protected Platform platform;

        protected LoginPage LoginPage;
        protected NewItemPage NewItemPage;

        protected BaseTest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        virtual public void BeforeEachTest()
        {
            if (platform == Platform.Android)
            {
//                app = ConfigureApp.iOS.AppBundle(path).DeviceIdentifier("B1F11589-E9D8-4FE8-A26E-C648C117D061").StartApp();
            }
            app = AppInitializer.StartApp(platform);
            app.Screenshot("App Initialized");

            LoginPage = new LoginPage(app, platform);
            NewItemPage = new NewItemPage(app, platform);
        }
    }
}