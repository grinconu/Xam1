using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace App_Pruebas.View
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.LoginViewModel(Navigation);
        }
    }
}
