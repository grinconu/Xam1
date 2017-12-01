using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Content;
using Android.Util;
using Gcm.Client;
using Utilidades.Enum;
using Utilidades.Settings;
using WindowsAzure.Messaging;

namespace App_Pruebas.Droid
{
    [Service]
    public class PushHandlerService : GcmServiceBase
    {
        /// <summary>
        /// Gets the registration identifier.
        /// </summary>
        /// <value>The registration identifier.</value>
        public static string RegistrationID { get; private set; }

        /// <summary>
        /// Gets or sets the hub.
        /// </summary>
        /// <value>The hub.</value>
        private NotificationHub Hub { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:App_Pruebas.Droid.PushHandlerService"/> class.
        /// </summary>
        public PushHandlerService() : base(SettingsApp.Data.Notification.AndroidId)
        {
            Utilidades.Log.Log.RecordTrace("PushHandlerService() constructor.", TypeLog.Trace, Pilicy.Client);
        }

        /// <summary>
        /// Ons the message.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="intent">Intent.</param>
        protected override void OnMessage(Context context, Intent intent)
        {
            Utilidades.Log.Log.RecordTrace("GCM Message Received!", TypeLog.Trace, Pilicy.Client);

            var msg = new StringBuilder();

            if (intent != null && intent.Extras != null)
            {
                foreach (var key in intent.Extras.KeySet())
                    msg.AppendLine(key + "=" + intent.Extras.Get(key).ToString());
            }

            string messageText = intent.Extras.GetString("message");
            if (!string.IsNullOrEmpty(messageText))
            {
                createNotification("New hub message!", messageText);
            }
            else
            {
                createNotification("Unknown message details", msg.ToString());
            }
        }

        /// <summary>
        /// Ons the registered.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="registrationId">Registration identifier.</param>
        protected override void OnRegistered(Context context, string registrationId)
        {
            Utilidades.Log.Log.RecordTrace($"GCM Registered: {registrationId}", TypeLog.Trace, Pilicy.Client);
            RegistrationID = registrationId;

            //createNotification("PushHandlerService-GCM Registered...",
            //                   "The device has been Registered!");

            Hub = new NotificationHub(SettingsApp.Data.Notification.NotificationHubName
                                      , SettingsApp.Data.Notification.ListenConnectionString,
                                        context);
            try
            {
                Hub.UnregisterAll(registrationId);
            }
            catch (Exception ex)
            {
                Utilidades.Log.Log.RecordLog(ex, TypeLog.Error, Pilicy.Client);
            }

            //var tags = new List<string>() { "falcons" }; // create tags if you want
            var tags = new List<string>() { };

            try
            {
                var hubRegistration = Hub.Register(registrationId, tags.ToArray());
            }
            catch (Exception ex)
            {
                Utilidades.Log.Log.RecordLog(ex, TypeLog.Error, Pilicy.Client);
            }
        }

        /// <summary>
        /// Ons the un registered.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="registrationId">Registration identifier.</param>
        protected override void OnUnRegistered(Context context, string registrationId)
        {
            Utilidades.Log.Log.RecordTrace($"GCM Unregistered: {registrationId}", TypeLog.Trace, Pilicy.Client);
            createNotification("GCM Unregistered...", "The device has been unregistered!");
        }

        /// <summary>
        /// Ons the recoverable error.
        /// </summary>
        /// <returns><c>true</c>, if recoverable error was oned, <c>false</c> otherwise.</returns>
        /// <param name="context">Context.</param>
        /// <param name="errorId">Error identifier.</param>
        protected override bool OnRecoverableError(Context context, string errorId)
        {
            Utilidades.Log.Log.RecordTrace($"Recoverable Error: {errorId}", TypeLog.Trace, Pilicy.Client);
            return base.OnRecoverableError(context, errorId);
        }

        /// <summary>
        /// Ons the error.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="errorId">Error identifier.</param>
        protected override void OnError(Context context, string errorId)
        {
            Utilidades.Log.Log.RecordTrace($"GCM Error: {errorId}", TypeLog.Trace, Pilicy.Client);
        }

        /// <summary>
        /// Creates the notification.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="desc">Desc.</param>
        void createNotification(string title, string desc)
        {
            //Create notification
            var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            //Create an intent to show UI
            var uiIntent = new Intent(this, typeof(MainActivity));

            //Create the notification
            var notification = new Notification(Android.Resource.Drawable.SymActionEmail, title);

            //Auto-cancel will remove the notification once the user touches it
            notification.Flags = NotificationFlags.AutoCancel;

            //Set the notification info
            //we use the pending intent, passing our ui intent over, which will get called
            //when the notification is tapped.
            notification.SetLatestEventInfo(this, title, desc, PendingIntent.GetActivity(this, 0, uiIntent, 0));

            //Show the notification
            notificationManager.Notify(1, notification);
            dialogNotify(title, desc);
        }

        /// <summary>
        /// Dialogs the notify.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
        protected void dialogNotify(String title, String message)
        {
            MainActivity.instance.RunOnUiThread(() => {
                AlertDialog.Builder dlg = new AlertDialog.Builder(MainActivity.instance);
                AlertDialog alert = dlg.Create();
                alert.SetTitle(title);
                alert.SetButton("Ok", delegate {
                    alert.Dismiss();
                });
                alert.SetMessage(message);
                alert.Show();
            });
        }
    }
}
