using System;
using Android.Content;
using Android.Net;
using Facade.Base;
using Java.Net;
using Utilidades.Enum;
using Utilidades.Log;
using Xamarin.Forms;

///Se indica cual es la referencia que debe tomar la dependencia de android.
[assembly: Dependency(typeof(App_Pruebas.Droid.Facade.Connection))]
namespace App_Pruebas.Droid.Facade
{
    /// <summary>
    /// Conexion Servicios.
    /// </summary>
    public class Connection: IConnection
    {
        /// <summary>
        /// Conectados the red.
        /// </summary>
        /// <returns><c>true</c>, if red was conectadoed, <c>false</c> otherwise.</returns>
        public bool ConectadoRed()
        {
            ConnectivityManager connectivityManager = 
                (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;

            return (activeConnection != null && activeConnection.IsConnected);
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <returns>The file path.</returns>
        /// <param name="dbName">Db name.</param>
        public string GetFilePath(string dbName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, dbName);
        }

        /// <summary>
        /// Respondes the servicio.
        /// </summary>
        /// <returns><c>true</c>, if servicio was responded, <c>false</c> otherwise.</returns>
        /// <param name="Uri">URI.</param>
        public bool RespondeServicio(string Uri)
        {
            try
            {
                URL myUrl = new URL(Uri);
                URLConnection connection = myUrl.OpenConnection();
                connection.ConnectTimeout = 3000;
                var resultado = connection.ConnectAsync();
                resultado.Wait();
                return true;
            }
            catch (Exception ex)
            {
                Log.RecordLog(ex, TypeLog.Error,Pilicy.Client);
                return false;
            }
        }
    }
}
