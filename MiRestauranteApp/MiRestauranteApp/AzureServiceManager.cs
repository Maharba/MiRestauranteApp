using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Plugin.Connectivity;

namespace MiRestauranteApp
{
    public class AzureServiceManager
    {
        public MobileServiceClient ServiceClient { get; set; }

        private IMobileServiceSyncTable<Platillo> _tablaPlatillo;
        private bool _isInitilized;

        private readonly string AzureURL = "http://mirestaurante-app.azurewebsites.net";

        private async Task Initialize()
        {
            if (ServiceClient?.SyncContext?.IsInitialized ?? false)
                return;

            ServiceClient = new MobileServiceClient(AzureURL);

            var path = "mirestaurante.db3";
            path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);

            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<Platillo>();

            await ServiceClient.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

            _tablaPlatillo = ServiceClient.GetSyncTable<Platillo>();
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

        public async Task AgregarPlatillo(Platillo platillo)
        {
            await Initialize();

            await _tablaPlatillo.InsertAsync(platillo);

            await SyncPlatillos();
        }
    }
}
