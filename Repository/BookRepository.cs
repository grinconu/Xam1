namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    /// <summary>
    /// Book repository.
    /// </summary>
    public class BookRepository : Base.Repository
    {
        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>The status message.</value>
        public string StatusMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Repository.BookRepository"/> class.
        /// </summary>
        /// <param name="dbpath">Dbpath.</param>
        public BookRepository(string dbpath) : base(dbpath)
        {
        }

        /// <summary>
        /// Adds the book async.
        /// </summary>
        /// <returns>The book async.</returns>
        /// <param name="book">Book.</param>
        public async Task AddBookAsync(Book book)
        {
            try
            {
                if (book == null)
                    throw new ArgumentNullException(nameof(book));

                var resul = await base.conn.InsertAsync((book))
                                       .ConfigureAwait(continueOnCapturedContext: false);
                this.StatusMessage = $"{resul} Se agrego correctamente el registro";
            }
            catch(Exception ex)
            {
                this.StatusMessage = $"Se genero error al agregar el registro, {ex.Message}";
            }
        }

        /// <summary>
        /// Gets all books async.
        /// </summary>
        /// <returns>The all books async.</returns>
        public Task<List<Book>> GetAllBooksAsync()
        {
            try
            {
                this.StatusMessage = "OK";
                //conn.DropTableAsync<Book>();
                return conn.Table<Book>().ToListAsync();
            }
            catch(Exception ex)
            {
                this.StatusMessage = $"Se genero error al consultar los registros, {ex.Message}";
                return null;
            }
        }
    }
}