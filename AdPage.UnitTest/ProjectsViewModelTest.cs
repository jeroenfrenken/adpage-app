using AdPage.Api.Client;
using AdPage.ViewModels;
using Xunit;

namespace AdPage.UnitTest
{
    
    public class ProjectsViewModelTest
    {
        
        private readonly ProjectsViewModel _projectsViewModel = new ProjectsViewModel();
        
        [Fact]
        public async void GetProjects()
        {
            ApiClient.Instance.setApiKey(
                "TOKEN"
            );
            
            await _projectsViewModel.ExecuteLoadItemsCommand();
            Assert.True(_projectsViewModel.Projects.Count > 0);
        }
        
        

    }
    
}