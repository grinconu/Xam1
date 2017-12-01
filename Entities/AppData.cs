namespace Entities
{
    /// <summary>
    /// App data.
    /// </summary>
    public class AppData
    {
        /// <summary>
        /// Gets or sets the notification.
        /// </summary>
        /// <value>The notification.</value>
        public Notification Notification { get; set; }

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        /// <value>The services.</value>
        public Services Services { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public string User
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the DB Name SQLite.
        /// </summary>
        /// <value>The DBN ame.</value>
        public string DBName
        {
            get;
            set;
        }
    }
}
