using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MiRestauranteApp.Annotations;
using MiRestauranteApp.Interfaces;
using MiRestauranteApp.Models;

namespace MiRestauranteApp.ViewModels
{
    public class PlatilloViewModel : ViewModelBase
    {
        private readonly IPlatilloService _platillosService;
        public ObservableCollection<Platillo> Platillos { get; set; }

        public PlatilloViewModel(IPlatilloService plattiService)
        {
            if (plattiService == null) throw new ArgumentNullException("peopleService");
            _platillosService = plattiService;
        }

        public async Task Init()
        {
            if (Platillos != null) return;
            Platillos = new ObservableCollection<Platillo>(await _platillosService.ObtenerPlatillos());
        }
    }
}
