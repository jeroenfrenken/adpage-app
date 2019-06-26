using System;
using System.Threading.Tasks;
using AdPage.Api.Client;
using AdPage.Api.Model;

namespace AdPage.ViewModels
{
    public class LeadDetailViewModel: BaseViewModel
    {


        public ProjectLeadDto ProjectLeadDto;

        public LeadDetailViewModel(ProjectLeadDto projectLeadDto = null)
        {
            Title = "Lead overview";
            ProjectLeadDto = projectLeadDto;
        }
        
        
        async Task LoadProjectLeads()
        {
            try
            {
                var projectLeads = await ApiClient.Instance.DeleteLead(ProjectLeadDto.ProjectUuid, ProjectLeadDto.Uuid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        
    }
}