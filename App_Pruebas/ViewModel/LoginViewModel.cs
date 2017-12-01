namespace App_Pruebas.ViewModel
{
    using System.Windows.Input;
    using App_Pruebas.View;
    using App_Pruebas.ViewModel.Base;
    using Utilidades.Settings;
    using Xamarin.Forms;

    /// <summary>
    /// Login view model.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// The usuario.
        /// </summary>
        private string _Usuario;

        /// <summary>
        /// The password.
        /// </summary>
        private string _Password;

        /// <summary>
        /// The texto mensaje.
        /// </summary>
        private string _TextoMensaje;

        /// <summary>
        /// The enabled aceptar.
        /// </summary>
        private bool _EnabledAceptar;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:App_Pruebas.ViewModel.LoginViewModel"/> class.
        /// </summary>
        /// <param name="navigation">Navigation.</param>
        public LoginViewModel(INavigation navigation)
        {
            this.ValidarUsuarioCommand = new Command(ValidarUsuario);
            this.CancelarCommand = new Command(LimpiarCampos);
            base.Navigation = navigation;
            this.EnabledAceptar = false;
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
        /// Gets the validar usuario command.
        /// </summary>
        /// <value>The validar usuario command.</value>
        public ICommand ValidarUsuarioCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the cancelar command.
        /// </summary>
        /// <value>The cancelar command.</value>
        public ICommand CancelarCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the usuario.
        /// </summary>
        /// <value>The usuario.</value>
        public string Usuario
        {
            get => _Usuario;
            set
            {
                _Usuario = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get => _Password;
            set
            {
                _Password = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:App_Pruebas.ViewModel.LoginViewModel"/> enabled aceptar.
        /// </summary>
        /// <value><c>true</c> if enabled aceptar; otherwise, <c>false</c>.</value>
        public bool EnabledAceptar
        {
            get => _EnabledAceptar;
            set
            {
                _EnabledAceptar = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Validars the usuario.
        /// </summary>
        private void ValidarUsuario()
        {
            if (this.Usuario == SettingsApp.Data.User
                && this.Password == SettingsApp.Data.Password)
            {
                App_Pruebas.App.Current.MainPage = new NavigationPage(new MasterPage());
            }
            else
            {
                this.TextoMensaje = "Usuario o contraseña son incorrectos.";
            }
        }

        /// <summary>
        /// Limpiar los campos.
        /// </summary>
        private void LimpiarCampos()
        {
            this.Usuario = string.Empty;
            this.Password = string.Empty;
            this.TextoMensaje = string.Empty;
        }
    }
}