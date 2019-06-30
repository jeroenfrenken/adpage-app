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
                "lTsJlhD9sJ1J43xxPz8zZG9THyNMqR98nmiA7viR6wwcGfqdVsVdLUkBot5t2QeLLcKxUgsavURm82Ka9psp5LNo4sOmd9zWjEAC0V1y4gJ64FgflLOjWUbWYgwTWSJT"
            );
            
            await _projectsViewModel.ExecuteLoadItemsCommand();
            Assert.True(_projectsViewModel.Projects.Count > 0);
        }
        
        

    }
    
}