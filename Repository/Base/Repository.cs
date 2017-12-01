namespace Repository.Base
{
    using Entities;
    using SQLite;

    /// <summary>
    /// Repository.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// The conn.
        /// </summary>
        public readonly SQLiteAsyncConnection conn;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Repository.Base.Repository"/> class.
        /// </summary>
        /// <param name="dbPath">Db path.</param>
        public Repository(string dbPath)
        {
            this.conn = new SQLiteAsyncConnection(dbPath);
            this.conn.CreateTableAsync<Book>().Wait();
        }
    }
}
