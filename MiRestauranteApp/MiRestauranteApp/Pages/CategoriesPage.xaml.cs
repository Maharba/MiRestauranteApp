using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiRestauranteApp.Models;
using MiRestauranteApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MiRestauranteApp.Pages
{
    public partial class CategoriesPage : ContentPage
    {
        private TapGestureRecognizer _tap;
        private AzureServiceManager _azureServiceManager;

        public CategoriesPage()
        {
            InitializeComponent();

            _tap = new TapGestureRecognizer();
            _tap.Tapped += TapOnTapped;
            _azureServiceManager = new AzureServiceManager();
            lstCategorias.ItemSelected += (sender, args) =>
            {
                ((ListView) sender).SelectedItem = null;
            };
            lstCategorias.ItemTapped += LstCategoriasOnItemTapped;
            //crcPaninis.GestureRecognizers.Add(_tap);
        }

        private async void LstCategoriasOnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            var categoriaSeleccionada = itemTappedEventArgs.Item as Categoria;
            if (categoriaSeleccionada != null)
            {
                await Navigation.PushAsync(new PlatillosPage(categoriaSeleccionada.Nombre));
            }
        }

        private async void TapOnTapped(object sender, EventArgs eventArgs)
        {
            await Navigation.PushModalAsync(new PlatillosPage("Paninis"));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lstCategorias.ItemsSource = await _azureServiceManager.ObtenerCategorias();
            //grdMain.Opacity = 0;
            //await grdMain.FadeTo(1, 500);
        }
    }
}
