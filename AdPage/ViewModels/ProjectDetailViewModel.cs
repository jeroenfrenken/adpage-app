using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using AdPage.Api.Client;
using AdPage.Api.Model;
using Xamarin.Forms;

namespace AdPage.ViewModels
{
    public class ProjectDetailViewModel : BaseViewModel
    {
        public ProjectDto Project { get; set; }
        
        public ObservableCollection<ProjectLeadDto> Leads { get; set; }

        public Command LoadLeadCommand { get; set; }
        
        public ProjectDetailViewModel(ProjectDto project = null)
        {
            Title = project?.name;
            Project = project;
            Leads = new ObservableCollection<ProjectLeadDto>();
            LoadLeadCommand = new Command(async () => await LoadProjectLeads());
        }

        async Task LoadProjectLeads()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Leads.Clear();
                var projectLeads = await ApiClient.Instance.GetProjectLeads(Project.uuid);
                foreach (var lead in projectLeads)
                {
                    Leads.Add(new ProjectLeadDto
                    {
                        Uuid = lead["uuid"],
                        Ip = lead["ip"],
                        Posted = lead["posted"],
                        Data = lead,
                        Display = lead.ContainsKey("Email") ? $"Email: {lead["Email"]}" : $"Uuid: {lead["uuid"]}",
                        ProjectUuid = Project.uuid
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
