using System.ComponentModel;
using AdPage.Api.Model;
using Xamarin.Forms;
using AdPage.ViewModels;

namespace AdPage.Views
{
    [DesignTimeVisible(false)]
    public partial class ProjectDetailPage : ContentPage
    {
        private ProjectDetailViewModel _viewModel;

        public ProjectDetailPage(ProjectDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this._viewModel = viewModel;
        }

        public ProjectDetailPage()
        {
            InitializeComponent();
            _viewModel = new ProjectDetailViewModel();
            BindingContext = _viewModel;
        }
        
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
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
            _viewModel.LoadLeadCommand.Execute(null);
        }
    }
}