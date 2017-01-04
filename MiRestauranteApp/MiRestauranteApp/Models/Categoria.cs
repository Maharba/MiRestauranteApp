using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiRestauranteApp.Models
{
    public class Categoria : AzureBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
