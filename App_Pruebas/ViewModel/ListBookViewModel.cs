using System;
using System.Collections.Generic;
using App_Pruebas.ViewModel.Base;
using Entities;
using Facade.Book;
using Utilidades.Enum;
using Utilidades.Settings;
using Xamarin.Forms;

namespace App_Pruebas.ViewModel
{
    /// <summary>
    /// List book view model.
    /// </summary>
    public class ListBookViewModel : BaseViewModel
    {
        /// <summary>
        /// The list books.
        /// </summary>
        private List<Book> _listBooks;

        /// <summary>
        /// The book facade.
        /// </summary>
        private BookFacade bookFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:App_Pruebas.ViewModel.AddBookViewModel"/> class.
        /// </summary>
        public ListBookViewModel(INavigation navigation)
        {
            this.CargarControles();
            base.Navigation = navigation;
        }

        /// <summary>
        /// Cargars the controles.
        /// </summary>
        private async void CargarControles()
        {
            try
            {
                if (bookFacade == null)
                    bookFacade = new BookFacade(
                        SettingsApp.Data.Services.ApiRest,
                            SettingsApp.Data.DBName);
                var resul = await bookFacade.FindAllBooks();

                this.ListBooks = resul;
            }
            catch (Exception ex)
            {
                Utilidades.Log.Log.RecordLog(ex, TypeLog.Error, Pilicy.Client);
            }
        }

        /// <summary>
        /// Gets or sets the list books.
        /// </summary>
        /// <value>The list books.</value>
        public List<Book> ListBooks
        {
            get => _listBooks;
            set
            {
                _listBooks = value;
                base.OnPropertyChangeEventHandler();
            }
        }
    }
}
