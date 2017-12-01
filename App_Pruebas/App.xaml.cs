using System.IO;
using System.Reflection;
using Facade.Base;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace App_Pruebas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            this.LoadData();
#if DEBUG           
            MainPage = new View.LoginView();
#else
            MainPage = new View.LoginView();
#endif
        }

        protected override void OnStart()
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

        private void LoadData()
        {
            Utilidades.Settings.SettingsApp.LoadDataApp(this.GetType().GetTypeInfo());
        }
    }
}
