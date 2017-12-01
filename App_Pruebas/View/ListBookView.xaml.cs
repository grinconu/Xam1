using System;
using System.Collections.Generic;
using App_Pruebas.ViewModel;
using Xamarin.Forms;

namespace App_Pruebas.View
{
    public partial class ListBookView : ContentPage
    {
        public ListBookView()
        {
            InitializeComponent();
            this.BindingContext = new ListBookViewModel(Navigation);
        }
    }
}
