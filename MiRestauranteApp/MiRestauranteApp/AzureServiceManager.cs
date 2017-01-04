using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MiRestauranteApp.Models;
using Plugin.Connectivity;

namespace MiRestauranteApp
{
    public class AzureServiceManager
    {
        public MobileServiceClient ServiceClient { get; set; }

        private IMobileServiceSyncTable<Platillo> _tablaPlatillo;
        private IMobileServiceSyncTable<Categoria> _tablaCategoria;
        private bool _isInitilized;

        private readonly string AzureURL = "http://mirestaurante-app.azurewebsites.net";

        public  async Task Initialize()
        {
            if (ServiceClient?.SyncContext?.IsInitialized ?? false)
                return;

            ServiceClient = new MobileServiceClient(AzureURL);

            var path = "mirestaurante.db3";
            path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);

            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<Platillo>();
            store.DefineTable<Categoria>();

            await ServiceClient.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

            _tablaPlatillo = ServiceClient.GetSyncTable<Platillo>();
            _tablaCategoria = ServiceClient.GetSyncTable<Categoria>();
        }

        private async Task SyncPlatillos()
        {
            if (CrossConnectivity.Current.IsConnected && await CrossConnectivity.Current.IsRemoteReachable(AzureURL))
            {
                try
                {
                    await ServiceClient.SyncContext.PushAsync();
                    await _tablaPlatillo.PullAsync("platillos", _tablaPlatillo.CreateQuery());
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }

        public async Task<List<Platillo>> ObtenerPlatillos()
        {
            await Initialize();
            await SyncPlatillos();
            return await _tablaPlatillo.ToListAsync();
        }

        public async Task<List<Platillo>> ObtenerPlatillosPorCategoria(string categoria)
        {
            await Initialize();
            await SyncPlatillos();
            return await _tablaPlatillo.Where(p => p.Categoria == categoria).ToListAsync();
        }

        public async Task AgregarPlatillo(Platillo platillo)
        {
            await Initialize();

            await _tablaPlatillo.InsertAsync(platillo);

            await SyncPlatillos();
        }

        private async Task SyncCategorias()
        {
            if (CrossConnectivity.Current.IsConnected && await CrossConnectivity.Current.IsRemoteReachable(AzureURL))
            {
                try
                {
                    await ServiceClient.SyncContext.PushAsync();
                    await _tablaPlatillo.PullAsync("categorias", _tablaCategoria.CreateQuery());
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<List<Categoria>> ObtenerCategorias()
        {
            await Initialize();
            await SyncCategorias();
            return await _tablaCategoria.ToListAsync();
        }

        public async Task AgregarCategoria(Categoria categoria)
        {
            await Initialize();

            await _tablaCategoria.InsertAsync(categoria);

            await SyncCategorias();
        }
    }
}
