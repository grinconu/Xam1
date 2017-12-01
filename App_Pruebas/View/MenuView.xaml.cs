namespace App_Pruebas.View
{
    using App_Pruebas.ViewModel;
    using Xamarin.Forms;

    /// <summary>
    /// Menu view.
    /// </summary>
    public partial class MenuView : ContentPage
    {
        /// <summary>
        /// Gets the list view.
        /// </summary>
        /// <value>The list view.</value>
        public ListView ListView { get { return listView; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:App_Pruebas.View.MenuView"/> class.
        /// </summary>
        public MenuView()
        {
            InitializeComponent();
            this.BindingContext = new MenuViewModel(Navigation);//, (this.Parent as MasterPage));
        }
    }
}
