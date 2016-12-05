using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiRestauranteApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var azureService = new AzureServiceManager();
            var platillos = await azureService.ObtenerPlatillos();
            lstPlatillos.ItemsSource = platillos;
        }
    }
}
