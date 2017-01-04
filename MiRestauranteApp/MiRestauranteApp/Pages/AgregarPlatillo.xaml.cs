using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiRestauranteApp.Models;
using Xamarin.Forms;

namespace MiRestauranteApp.Pages
{
    public partial class AgregarPlatillo : ContentPage
    {
        private AzureServiceManager _azureServiceManager;

        public AgregarPlatillo()
        {
            InitializeComponent();

            _azureServiceManager = new AzureServiceManager();
            btnGuardar.Clicked += BtnGuardarOnClicked;
        }

        private async void BtnGuardarOnClicked(object sender, EventArgs eventArgs)
        {
            await _azureServiceManager.AgregarPlatillo(new Platillo()
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Categoria = txtCategoria.Text,
                Precio = Convert.ToDouble(txtPrecio.Text),
                Imagen = txtImagen.Text
            });
        }
    }
}
