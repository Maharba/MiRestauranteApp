using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiRestauranteApp.Interfaces;
using MiRestauranteApp.Models;

namespace MiRestauranteApp.Services
{
    public class PlatillosServiceStub : IPlatilloService
    {
        public Task<IEnumerable<Platillo>> ObtenerPlatillos()
        {
            return Task.Run(() => GenerarPlatillos());
        }

        private IEnumerable<Platillo> GenerarPlatillos()
        {
            var platillos = new List<Platillo>();
            platillos.Add(new Platillo()
            {
                Nombre = "Quesabrosas Bacon",
                Descripcion = "Un bombazo de sabor",
                Imagen = "a4.png",
                Categoria = "Quesabrosas",
                Precio = 99
            });
            return platillos;
        }
    }
}
