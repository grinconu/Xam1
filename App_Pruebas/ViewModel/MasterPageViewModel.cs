namespace App_Pruebas.ViewModel
{
    using System.Collections.Generic;
    using App_Pruebas.ViewModel.Base;
    using App_Pruebas.View;
    using Entities;
    using Xamarin.Forms;

    /// <summary>
    /// Master page view model.
    /// </summary>
    public class MasterPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:App_Pruebas.ViewModel.MasterPageViewModel"/> class.
        /// </summary>
        /// <param name="navigation">Navigation.</param>
        public MasterPageViewModel(INavigation navigation)
        {
            base.Navigation = navigation;
        }
    }
}
