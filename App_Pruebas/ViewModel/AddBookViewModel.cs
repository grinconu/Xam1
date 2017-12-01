namespace App_Pruebas.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using App_Pruebas.ViewModel.Base;
    using Entities;
    using Facade.Book;
    using Utilidades.Settings;
    using Xamarin.Forms;

    /// <summary>
    /// Add book view model.
    /// </summary>
    public class AddBookViewModel: BaseViewModel
    {
        /// <summary>
        /// The codigo.
        /// </summary>
        private string _Codigo;

        /// <summary>
        /// The nombre.
        /// </summary>
        private string _Nombre;

        /// <summary>
        /// The autor.
        /// </summary>
        private string _Autor;

        /// <summary>
        /// The ano.
        /// </summary>
        private string _Ano;

        /// <summary>
        /// The descripcion.
        /// </summary>
        private string _Descripcion;

        /// <summary>
        /// The idioma.
        /// </summary>
        private string _Idioma;

        /// <summary>
        /// The enabled aceptar.
        /// </summary>
        private bool _EnabledAceptar;

        /// <summary>
        /// The texto mensaje.
        /// </summary>
        private string _TextoMensaje;

        /// <summary>
        /// The idiomas.
        /// </summary>
        private List<string> _Idiomas;

        /// <summary>
        /// The registrar libro.
        /// </summary>
        public ICommand RegistrarLibro
        {
            get;
            private set;
        }

        /// <summary>
        /// The limpiar.
        /// </summary>
        public ICommand Limpiar
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:App_Pruebas.ViewModel.AddBookViewModel"/> class.
        /// </summary>
        /// <param name="navigation">Navigation.</param>
        public AddBookViewModel(INavigation navigation)
        {
            base.Navigation = navigation;
            this.RegistrarLibro = new Command(this.RegistrarInformacion);
            this.Limpiar = new Command(this.LimpiarCampos);

            this.Idiomas = new List<string> { "Español", "Ingles", "Frances" };
        }

        /// <summary>
        /// Gets or sets the codigo.
        /// </summary>
        /// <value>The codigo.</value>
        public string Codigo
        {
            get => _Codigo;
            set
            {
                this._Codigo = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>The nombre.</value>
        public string Nombre
        {
            get => _Nombre;
            set
            {
                this._Nombre = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Gets or sets the autor.
        /// </summary>
        /// <value>The autor.</value>
        public string Autor
        {
            get => _Autor;
            set
            {
                this._Autor = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Gets or sets the ano.
        /// </summary>
        /// <value>The ano.</value>
        public string Ano
        {
            get => _Ano;
            set
            {
                this._Ano = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Gets or sets the descripcion.
        /// </summary>
        /// <value>The descripcion.</value>
        public string Descripcion
        {
            get => _Descripcion;
            set
            {
                this._Descripcion = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Gets or sets the idioma.
        /// </summary>
        /// <value>The idioma.</value>
        public string Idioma
        {
            get => _Idioma;
            set
            {
                this._Idioma = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:App_Pruebas.ViewModel.AddBookViewModel"/> enabled aceptar.
        /// </summary>
        /// <value><c>true</c> if enabled aceptar; otherwise, <c>false</c>.</value>
        public bool EnabledAceptar
        {
            get => _EnabledAceptar;
            set
            {
                this._EnabledAceptar = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Gets or sets the texto mensaje.
        /// </summary>
        /// <value>The texto mensaje.</value>
        public string TextoMensaje
        {
            get => _TextoMensaje;
            set
            {
                this._TextoMensaje = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Gets or sets the idiomas.
        /// </summary>
        /// <value>The idiomas.</value>
        public List<string> Idiomas
        {
            get => this._Idiomas;
            set
            {
                this._Idiomas = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Gets or sets the facade.
        /// </summary>
        /// <value>BookFacade.</value>
        public BookFacade Facade
        {
            get;
            set;
        }

        /// <summary>
        /// Registrar la informacion.
        /// </summary>
        private void RegistrarInformacion()
        {
            this.InsertarLibro();
        }

        /// <summary>
        /// Insertars the libro.
        /// </summary>
        private async void InsertarLibro()
        {
            try
            {
                if (Facade == null)
                    Facade = new BookFacade(
                        SettingsApp.Data.Services.ApiRest,
                        SettingsApp.Data.DBName);
                var book = this.ObtenerInformacionLibro();

                var resul = await Facade.InsertBook(book);

                if (resul)
                    this.TextoMensaje = "Se guardo correctamente.";
                else
                    this.TextoMensaje = "Se genero error al guardar.";

            }
            catch (Exception ex)
            {
                Utilidades.Log.Log.RecordLog(
                    ex,
                    Utilidades.Enum.TypeLog.Error,
                    Utilidades.Enum.Pilicy.Client);
            }
        }

        /// <summary>
        /// Obteners the informacion libro.
        /// </summary>
        private Book ObtenerInformacionLibro()
        {
            return new Book
            {
                Author = this.Autor,
                Codigo = Convert.ToInt32(this.Codigo),
                Description = this.Descripcion,
                Language = this.Idioma,
                Name = this.Nombre,
                Yaer = this.Ano != string.Empty ? Convert.ToInt32(this.Ano) : 0
            };
        }

        /// <summary>
        /// Limpiars the campos.
        /// </summary>
        private void LimpiarCampos()
        {
            this.Codigo = string.Empty;
            this.Nombre = string.Empty;
            this.Autor = string.Empty;
            this.Ano = string.Empty;
            this.Descripcion = string.Empty;
            this.Idioma = string.Empty;
            this.TextoMensaje = string.Empty;
        }
    }
}