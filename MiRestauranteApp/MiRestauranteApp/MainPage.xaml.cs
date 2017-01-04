using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiRestauranteApp.Pages;
using Xamarin.Forms;

namespace MiRestauranteApp
{
    public partial class MainPage : MasterDetailPage
    {
        private bool _authenticated;

        public MainPage()
        {
            InitializeComponent();

            Detail = new NavigationPage(new CategoriesPage());
            

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (_authenticated)
            {
                var azureService = new AzureServiceManager();
                var platillos = await azureService.ObtenerPlatillos();
                //lstPlatillos.ItemsSource = platillos;
            }
        }
    }
}
