using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Gcm.Client;
using Utilidades.Settings;

namespace App_Pruebas.Droid
{
    [Activity(Label = "App_Pruebas.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        /// The instance.
        /// </summary>
        public static MainActivity instance;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="bundle">Bundle.</param>
        protected override void OnCreate(Bundle bundle)
        {
            instance = this;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());

            RegisterWithGCM();
        }

        /// <summary>
        /// Registers the with gcm.
        /// </summary>
        private void RegisterWithGCM()
        {
            // Check to ensure everything's set up right
            GcmClient.CheckDevice(this);
            GcmClient.CheckManifest(this);

            // Register for push notifications
            Log.Info("MainActivity", "Registering...");
            GcmClient.Register(this, SettingsApp.Data.Notification.AndroidId);
        }

    }
}
