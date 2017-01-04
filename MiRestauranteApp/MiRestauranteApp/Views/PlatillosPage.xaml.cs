using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiRestauranteApp.Models;
using Xamarin.Forms;

namespace MiRestauranteApp.Views
{
    public partial class PlatillosPage : ContentPage
    {
        private AzureServiceManager _azureServiceManager;
        private string _categoriaSeleccionada;

        public PlatillosPage(string categoria)
        {
            InitializeComponent();

            _azureServiceManager = new AzureServiceManager();
            _categoriaSeleccionada = categoria;
            /*List<Platillo> platillos = new List<Platillo>()
            {
                new Platillo()
                {
                    Nombre = "Panini Bacon", Descripcion = "Un delicioso panini con tocino, acelgas y muchas cosas wuuuuu", Imagen = "a14.jpg"
                },
                new Platillo()
                {
                    Nombre = "Panini Bacon", Descripcion = "Un delicioso panini con tocino, acelgas y muchas cosas wuuuuu", Imagen = "a14.jpg"
                },
                new Platillo()
                {
                    Nombre = "Panini Bacon", Descripcion = "Un delicioso panini con tocino, acelgas y muchas cosas wuuuuu", Imagen = "a14.jpg"
                },
                new Platillo()
                {
                    Nombre = "Panini Bacon", Descripcion = "Un delicioso panini con tocino, acelgas y muchas cosas wuuuuu", Imagen = "a14.jpg"
                },
                new Platillo()
                {
                    Nombre = "Panini Bacon", Descripcion = "Un delicioso panini con tocino, acelgas y muchas cosas wuuuuu", Imagen = "a14.jpg"
                },
                new Platillo()
                {
                    Nombre = "Panini Bacon", Descripcion = "Un delicioso panini con tocino, acelgas y muchas cosas wuuuuu", Imagen = "a14.jpg"
                },
                new Platillo()
                {
                    Nombre = "Panini Bacon", Descripcion = "Un delicioso panini con tocino, acelgas y muchas cosas wuuuuu", Imagen = "a14.jpg"
                },
                new Platillo()
                {
                    Nombre = "Panini Bacon", Descripcion = "Un delicioso panini con tocino, acelgas y muchas cosas wuuuuu", Imagen = "a14.jpg"
                },
                new Platillo()
                {
                    Nombre = "Panini Bacon", Descripcion = "Un delicioso panini con tocino, acelgas y muchas cosas wuuuuu", Imagen = "a14.jpg"
                }
            };*/

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var platillos = await _azureServiceManager.ObtenerPlatillosPorCategoria(_categoriaSeleccionada);
            lstPlatillos.ItemsSource = platillos;
        }
    }
}
