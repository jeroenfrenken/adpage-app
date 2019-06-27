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
        ProjectsViewModel viewModel;

        public ProjectsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProjectsViewModel();
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
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
            if (viewModel.Projects.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}