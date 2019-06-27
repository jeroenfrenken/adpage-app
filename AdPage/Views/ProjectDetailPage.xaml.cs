using System.ComponentModel;
using AdPage.Api.Model;
using Xamarin.Forms;
using AdPage.ViewModels;

namespace AdPage.Views
{
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
            viewModel = new ProjectDetailViewModel();
            BindingContext = viewModel;
        }
        
        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var projectLeadDto = args.SelectedItem as ProjectLeadDto;
            if (projectLeadDto == null)
                return;

            await Navigation.PushAsync(new LeadDetailPage(new LeadDetailViewModel(projectLeadDto)));

            LeadsListView.SelectedItem = null;
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadLeadCommand.Execute(null);
        }
    }
}