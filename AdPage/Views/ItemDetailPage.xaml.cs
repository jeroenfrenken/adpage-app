using System.ComponentModel;
using AdPage.Api.Model;
using Xamarin.Forms;
using AdPage.ViewModels;

namespace AdPage.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var project = new ProjectDto
            {
                uuid = "test",
                name = "Test",
                published = false
            };

            viewModel = new ItemDetailViewModel(project);
            BindingContext = viewModel;
        }
    }
}