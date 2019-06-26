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
        
        public async Task<bool> DeleteLead()
        {
            try
            {
                return await ApiClient.Instance.DeleteLead(ProjectLeadDto.ProjectUuid, ProjectLeadDto.Uuid);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        
    }
}