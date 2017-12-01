namespace Facade.Book {     using System;     using System.Threading.Tasks;     using Base;     using Newtonsoft.Json;     using Entities;     using System.Net.Http;     using System.Text;     using System.Diagnostics;
    using System.Collections.Generic;
    using Utilidades.Enum;
    using Xamarin.Forms;
    using Repository;

    public class BookFacade : RestService     {         /// <summary>         /// Initializes a new instance of the <see cref="T:Facade.Book.BookFacade"/> class.         /// </summary>         /// <param name="uri">URI.</param>         public BookFacade(string uri, string dbName): base(uri, dbName)         {         }          /// <summary>         /// Inserts the book.         /// </summary>         /// <returns>Result of execution.</returns>         /// <param name="book">Book.</param>         public async Task<bool> InsertBook(Book book)         {             try             {                 if (base.IsConnected())                 {
                    var uri = new Uri(string.Format(base.Uri, string.Empty));
                    var json = JsonConvert.SerializeObject(book);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(uri + "/books", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var resul =
                            JsonConvert.DeserializeObject<Result>(response.Content.ToString());
                        Debug.WriteLine($"Book Saved correctly. resul: {resul.Data} ");
                    }

                    return response.IsSuccessStatusCode;                 }                 else                 {                     var connection = DependencyService.Get<IConnection>();                     BookRepository repor = new BookRepository(connection.GetFilePath(base.DBName));                     await repor.AddBookAsync(book);                     return true;                 }             }             catch(Exception ex)             {                 Utilidades.Log.Log.RecordLog(ex, TypeLog.Error, Pilicy.Client);                 throw ex;             }         }          /// <summary>         /// Finds all books.         /// </summary>         /// <returns>The all books.</returns>         public async Task<List<Book>> FindAllBooks()         {             List<Book> books = new List<Book>();             try             {                 if (base.IsConnected())                 {                    var uri = new Uri($"{base.Uri}/books");
                    using (var client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(uri);
                        if (response.IsSuccessStatusCode)
                        {
                            Debug.WriteLine($"Book find all OK.");
                            var resul = await response.Content.ReadAsStringAsync();
                            var result =
                                JsonConvert.DeserializeObject<Result>(resul);

                            if (result.Data != null)
                            {
                                books = JsonConvert.DeserializeObject<List<Book>>(result.Data.ToString());
                            }
                        }
                    }                 }                 else                 {                     var connection = DependencyService.Get<IConnection>();                     BookRepository repor = new BookRepository(connection.GetFilePath(base.DBName));                     books = await repor.GetAllBooksAsync();                 }             }             catch(Exception ex)             {                 Utilidades.Log.Log.RecordLog(ex, TypeLog.Error, Pilicy.Client);                 throw ex;             }              return books;         }     } }