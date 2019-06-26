using System.ComponentModel;
using AdPage.Api.Model;
using Xamarin.Forms;
using AdPage.ViewModels;

namespace AdPage.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ProjectDetailPage : ContentPage
    {
        ProjectDetailViewModel viewModel;

        public ProjectDetailPage(ProjectDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ProjectDetailPage()
        {
            InitializeComponent();

            var project = new ProjectDto
            {
                uuid = "test",
                name = "Test",
                published = false
            };

            viewModel = new ProjectDetailViewModel(project);
            BindingContext = viewModel;
        }
        
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var ProjectLeadDto = args.SelectedItem as ProjectLeadDto;
            if (ProjectLeadDto == null)
                return;

            await Navigation.PushAsync(new LeadDetailPage(new LeadDetailViewModel(ProjectLeadDto)));

            LeadsListView.SelectedItem = null;
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Leads.Count == 0)
                viewModel.LoadLeadCommand.Execute(null);
        }
    }
}