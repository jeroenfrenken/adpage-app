using AdPage.ViewModels;
using Xunit;

namespace AdPage.UnitTest
{
    
    public class LoginViewModelTest
    {
        
        private readonly LoginViewModel _loginViewModel = new LoginViewModel();

        [Fact]
        public void EmailSetCorrect()
        {
            const string email = "EMAIL";
            _loginViewModel.Email = email;
            Assert.Equal(email, _loginViewModel.Email);
        }

        [Fact]
        public void PasswordSetCorrect()
        {
            const string password = "PASSWORD";
            _loginViewModel.Password = password;
            Assert.Equal(password, _loginViewModel.Password);
        }
        
        [Fact]
        public async void LoginSuccessTest()
        {
            _loginViewModel.Email = "EMAIL";
            _loginViewModel.Password = "PASSWORD";
            var res = await _loginViewModel.Login();
            Assert.True(res);
        }

    }
    
}