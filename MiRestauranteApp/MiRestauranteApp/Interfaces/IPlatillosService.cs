using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiRestauranteApp.Models;

namespace MiRestauranteApp.Interfaces
{
    public interface IPlatilloService
    {
        Task<IEnumerable<Platillo>> ObtenerPlatillos();
    }
}
