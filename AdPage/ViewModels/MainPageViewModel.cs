using System;
using System.Threading.Tasks;
using AdPage.Api.Client;

namespace AdPage.ViewModels
{
    public class MainPageViewModel: BaseViewModel
    {

        public async Task<bool> CheckIfTokenValid()
        {
            try
            {
                var user = await ApiClient.Instance.GetUser();
                return user.uuid != null;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        
    }
}