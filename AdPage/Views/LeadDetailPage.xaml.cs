using System;
using AdPage.Interfaces;
using AdPage.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeadDetailPage : ContentPage
    {
        LeadDetailViewModel viewModel;

        public LeadDetailPage(LeadDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            foreach (var property in viewModel.ProjectLeadDto.Data)
            {
                LeadProperties.Children.Add(new Label
                {
                    Text = $"{property.Key}: {property.Value}"
                });
            }
        }

        async void Delete(object sender, EventArgs args)
        {
            var hud = DependencyService.Get<IHud>();
            hud.Show("Loading...");
            var res = await viewModel.DeleteLead();
            if (res)
            {
                await Navigation.PopAsync();
                hud.Success("Success");
            }
            else
            {
                hud.Error("Failed to delete");
            }
        } 
        
    }
}