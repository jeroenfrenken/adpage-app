using System;
using System.Threading.Tasks;
using AdPage.Api.Client;
using AdPage.Api.Model;

namespace AdPage.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public async Task<bool> Login()
        {
            var userLoginDto = new UserLoginDto();
            userLoginDto.email = Email;
            userLoginDto.password = Password;

            try
            {
                var data = await ApiClient.Instance.AuthenticateUser(userLoginDto);
                if (data.token != null)
                {
                    ApiClient.Instance.setApiKey(data.token);
                    return true;
                }
                
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
    }
}