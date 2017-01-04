using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using MiRestauranteApp.Models;
using Xamarin.Forms;

namespace MiRestauranteApp.Pages
{
    public partial class AgregarCategoria : ContentPage
    {
        private AzureServiceManager _azureServiceManager;

        public AgregarCategoria()
        {
            InitializeComponent();

            btnGuardar.Clicked += BtnGuardarOnClicked;
        }

        private async void BtnGuardarOnClicked(object sender, EventArgs eventArgs)
        {
            await _azureServiceManager.AgregarCategoria(new Categoria()
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text
            });
        }
    }
}
