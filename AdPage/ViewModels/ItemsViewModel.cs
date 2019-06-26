using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using AdPage.Api.Client;
using AdPage.Api.Model;
using Xamarin.Forms;

namespace AdPage.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<ProjectDto> Projects { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Projects";
            Projects = new ObservableCollection<ProjectDto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Projects.Clear();
                var projects = await ApiClient.Instance.GetProjects();
                foreach (var item in projects)
                {
                    Projects.Add(item);
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