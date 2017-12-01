using System;
using Facade.Base;
using Xamarin.Forms;
using Plugin.Connectivity;
using Utilidades.Log;
using Utilidades.Enum;

///Se indica cual es la referencia que debe tomar la dependencia de android.
[assembly: Dependency(typeof(App_Pruebas.iOS.Facade.Connection))]
namespace App_Pruebas.iOS.Facade
{
    /// <summary>
    /// Connection.
    /// </summary>
    public class Connection : IConnection
    {
        /// <summary>
        /// Conectados the red.
        /// </summary>
        /// <returns><c>true</c>, if red was conectadoed, <c>false</c> otherwise.</returns>
        public bool ConectadoRed()
        {
            return CrossConnectivity.Current.IsConnected;
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <returns>The file path.</returns>
        /// <param name="dbName">Db name.</param>
        public string GetFilePath(string dbName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");

            if (!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);
            }

            return System.IO.Path.Combine(libFolder, dbName);
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
                return Reachability.IsHostReachable(Uri);
            }
            catch (Exception ex)
            {
                Log.RecordLog(ex, TypeLog.Error, Pilicy.Client);
                return false;
            }
        }
    }
}
