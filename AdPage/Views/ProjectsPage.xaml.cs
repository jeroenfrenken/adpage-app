using System;
using System.ComponentModel;
using AdPage.Api.Model;
using Xamarin.Forms;
using AdPage.ViewModels;

namespace AdPage.Views
{
    [DesignTimeVisible(false)]
    public partial class ProjectsPage : ContentPage
    {
        private ProjectsViewModel _viewModel;

        public ProjectsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ProjectsViewModel();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var project = args.SelectedItem as ProjectDto;
            if (project == null)
                return;

            await Navigation.PushAsync(new ProjectDetailPage(new ProjectDetailViewModel(project)));

            // Manually deselect item.
            ProjectsListView.SelectedItem = null;
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_viewModel.Projects.Count == 0)
                _viewModel.LoadItemsCommand.Execute(null);
        }
    }
}