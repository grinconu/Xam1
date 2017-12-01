namespace Utilidades.Settings
{
    using System.IO;
    using System.Reflection;
    using Entities;
    using Newtonsoft.Json;

    public static class SettingsApp
    {
        /// <summary>
        /// Gets or sets the data of Application.
        /// </summary>
        /// <value>The data.</value>
        public static AppData Data
        {
            get;
            set;
        }
        
        /// <summary>
        /// Loads the data app.
        /// </summary>
        /// <param name="info">Info.</param>
        public static void LoadDataApp(TypeInfo info)
        {
            var resource = "App_Pruebas.appsettings.json";//type.Namespace + "." + Device.OnPlatform("iOS", "Droid", "WinPhone") + ".appsettings.json";
            var stream = info.Assembly.GetManifestResourceStream(resource);
            if (stream != null)
            {
                using (var reader = new StreamReader(stream))
                {
                    Data = JsonConvert.DeserializeObject<AppData>(reader.ReadToEnd());
                }
            }
        }
    }
}
