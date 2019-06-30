using System;
using System.Threading.Tasks;
using AdPage.Api.Client;
using AdPage.Api.Model;
using Xamarin.Forms;

namespace AdPage.ViewModels
{
    public class UserViewModel: BaseViewModel
    {
        private UserDto userDto;
        public UserDto UserDto
        {
            get => userDto;
            set => SetProperty(ref userDto, value);
        }

        public Command UserCommand { get; set; }
        
        public UserViewModel()
        {
            Title = "Account";
            UserCommand = new Command(async () => await GetAccount());
        }

        private async Task GetAccount()
        {
            try
            {
                UserDto = await ApiClient.Instance.GetUser();
            }
            catch (Exception e)
            {
                UserDto = new UserDto();
            }
        }

        public void LogoutUser()
        {
            ApiClient.Instance.setApiKey("");
        }
    }
}