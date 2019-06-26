using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AdPage.Api.Client;
using AdPage.Api.Model;
using Newtonsoft.Json;
using RestSharp;
using Xamarin.Forms;

namespace AdPage.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ProjectDto Project { get; set; }
        
        public ProjectLeadDto ProjectLeads { get; set; }
        
        public Command LoadLeadCommand { get; set; }
        
        public ItemDetailViewModel(ProjectDto project = null)
        {
            Title = project?.name;
            Project = project;
            LoadLeadCommand = new Command(async () => await LoadProjectLeads());
            LoadLeadCommand.Execute(null);
        }

        async Task LoadProjectLeads()
        {

            try
            {
                var leads = await ApiClient.Instance.GetProjectLeads(Project.uuid);
                Console.WriteLine(JsonConvert.SerializeObject(leads));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
            }
        }
    }
}
