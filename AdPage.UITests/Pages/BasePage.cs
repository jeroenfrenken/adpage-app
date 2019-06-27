using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace AdPage.UITests.Pages
{
    public abstract class BasePage
    {
        readonly string pageTitle;

        protected readonly IApp app;
        protected readonly bool OnAndroid;
        protected readonly bool OniOS;

        protected BasePage(IApp app, Platform platform, string pageTitle)
        {
            this.app = app;

            OnAndroid = platform == Platform.Android;
            OniOS = platform == Platform.iOS;

            this.pageTitle = pageTitle;

        }
        public bool IsPageVisible => app.Query(pageTitle).Length > 0;

        public void WaitForPageToLoad()
        {
            app.WaitForElement(pageTitle);
        }
        
        protected void EnterText(Query textBoxQuery, string text)
        {
            app.ClearText(textBoxQuery);
            app.EnterText(textBoxQuery, text);
            app.DismissKeyboard();
        }
    }
}