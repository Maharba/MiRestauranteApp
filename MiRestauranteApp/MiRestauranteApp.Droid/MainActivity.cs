using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Auth0.SDK;
using CarouselView.FormsPlugin.Android;
using MiRestauranteApp.Interfaces;

namespace MiRestauranteApp.Droid
{
    [Activity(Label = "MiRestauranteApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true,
         ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IAuthenticate
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            App.Init((IAuthenticate)this);
            CarouselViewRenderer.Init();

            LoadApplication(new App());
        }

        private MobileServiceUser _user;

        public async Task<string> Authenticate()
        {
            Auth0.SDK.Auth0Client client = new Auth0Client("maharba.auth0.com",
                "vYjnffFbjC26wLobIFzUHLzobkoB6d7T");
            var user = await client.LoginAsync(this, "facebook");
            return user.Profile["email"].ToString();

            
            /*var message = string.Empty;
            try
            {
                AzureServiceManager _azure = new AzureServiceManager();
                await _azure.Initialize();
                _user = await _azure.ServiceClient.LoginAsync(this, MobileServiceAuthenticationProvider.Google);
                if (_user != null)
                {
                    message = $"Te has logueado como {_user.UserId}";
                    success = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("Sign-in result");
            builder.Create().Show();*/

            
        }
    }
}

