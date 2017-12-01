using System;

namespace Utilidades.Log
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Utilidades.Enum;
    using Utilidades.Settings;

    public static class Log
    {
        /// <summary>
        /// The client.
        /// </summary>
        private static HttpClient client;

        /// <summary>
        /// The URI.
        /// </summary>
        private static string Uri;

        /// <summary>
        /// Records the log.
        /// </summary>
        /// <param name="ex">Exeption.</param>
        /// <param name="type">Type of record.</param>
        /// <param name="policy">Policy.</param>
        public static void RecordLog(Exception ex, TypeLog type, Pilicy policy)
        {
             InsertLog($"Message: {ex.Message} - Trace: {ex.StackTrace}", type, policy);
        }

        /// <summary>
        /// Records the trace.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="type">Type.</param>
        /// <param name="policy">Policy.</param>
        public static void RecordTrace(string message, TypeLog type, Pilicy policy)
        {
            InsertLog(message, type, policy);    
        }

        /// <summary>
        /// Inserts the log.
        /// </summary>
        /// <returns>The log.</returns>
        /// <param name="menssage">Menssage.</param>
        /// <param name="type">Type.</param>
        /// <param name="policy">Policy.</param>
        private static async Task<bool> InsertLog(string menssage, TypeLog type, Pilicy policy)
        {
            try
            {
                if(client == null)
                {
                    client = new HttpClient();
                    client.MaxResponseContentBufferSize = 256000;
                    Uri = SettingsApp.Data.Services.ApiRestLog;
                }

                var uri = new Uri(Uri);
                var json = JsonConvert.SerializeObject(new Entities.Log
                {
                    Description = menssage,
                    Type = type.ToString(),
                    Policy = policy.ToString()
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                //No se realiza ninguna accion
            }

            return true;
        }
    }
}