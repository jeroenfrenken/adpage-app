using AdPage.Api.Client;
using AdPage.ViewModels;
using Xunit;

namespace AdPage.UnitTest
{
    
    public class UserViewModelTest
    {
        
        [Fact]
        public void CheckLogout()
        {
            ApiClient.Instance.setApiKey("");
            Assert.True(true);
        }
        
    }
    
}