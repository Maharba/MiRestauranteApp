using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using MiRestauranteApp.Interfaces;
using MiRestauranteApp.Pages;
using Xamarin.Forms;

namespace MiRestauranteApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MobileService = new AzureServiceManager();
            MainPage = new IntroPage();
        }

        protected override async void OnStart()
        {
            // Handle when your app starts

            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static AzureServiceManager MobileService;
        public static IAuthenticate Authenticator { get; set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }
    }
}
