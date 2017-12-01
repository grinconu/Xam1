namespace App_Pruebas.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using App_Pruebas.View;
    using App_Pruebas.ViewModel.Base;
    using Entities;
    using Xamarin.Forms;

    public class MenuViewModel : BaseViewModel
    {
        /// <summary>
        /// The item menu.
        /// </summary>
        private List<MasterPageItem> _ItemMenu;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:App_Pruebas.ViewModel.MasterPageViewModel"/> class.
        /// </summary>
        public MenuViewModel(INavigation navigation)//, MasterDetailPage master)
        {
            base.Navigation = navigation;
            //this.Parent = master;
            this.ItemMenu = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Title = "Agregar Libro",
                    TargetType = typeof(AddBookView)
                },
                new MasterPageItem
                {
                    Title = "Lista Libros",
                    TargetType = typeof(ListBookView)
                }
            };

            this.MenuSeleted = new Command(CambioMenu);
        }

        /// <summary>
        /// Gets the menu seleted.
        /// </summary>
        /// <value>The menu seleted.</value>
        public ICommand MenuSeleted
        {
            get;
        }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public MasterDetailPage Parent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item menu.
        /// </summary>
        /// <value>The item menu.</value>
        public List<MasterPageItem> ItemMenu
        {
            get => _ItemMenu;
            set
            {
                this._ItemMenu = value;
                base.OnPropertyChangeEventHandler();
            }
        }

        /// <summary>
        /// Cambios the menu.
        /// </summary>
        /// <param name="obj">Object.</param>
        void CambioMenu(object obj)
        {
            var item = obj as MasterPageItem;
            if (item != null)
            {
                Parent.Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                //Parent.masterPage.ListView.SelectedItem = null;
                Parent.IsPresented = false;
            }
        }
    }
}
