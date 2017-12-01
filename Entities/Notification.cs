namespace Entities
{
    public class Notification
    {
        /// <summary>
        /// Gets or sets the android identifier of notification Hub.
        /// </summary>
        /// <value>The android identifier.</value>
        public string AndroidId { get; set; }

        /// <summary>
        /// Gets or sets the listen connection string.
        /// </summary>
        /// <value>The listen connection string.</value>
        public string ListenConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the notification hub.
        /// </summary>
        /// <value>The name of the notification hub.</value>
        public string NotificationHubName
        {
            get;
            set;
        }
    }
}
