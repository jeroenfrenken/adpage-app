using System.ComponentModel;
using AdPage.Api.Model;
using Xamarin.Forms;
using AdPage.ViewModels;

namespace AdPage.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var project = args.SelectedItem as ProjectDto;
            if (project == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(project)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Projects.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}