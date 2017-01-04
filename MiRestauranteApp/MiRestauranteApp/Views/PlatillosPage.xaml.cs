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
        public PlatillosPage(string categoria)
        {
            InitializeComponent();

            //TODO: Realizar consulta con filtro por categoría
            List<Platillo> platillos = new List<Platillo>()
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
            };

            lstPlatillos.ItemsSource = platillos;
        }
    }
}
