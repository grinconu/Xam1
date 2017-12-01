using System;
using System.Collections.Generic;
using System.IO;
using App_Pruebas.ViewModel;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace App_Pruebas.View
{
    public partial class AddBookView : ContentPage
    {
        public AddBookView()
        {
            InitializeComponent();
            this.BindingContext = new AddBookViewModel(Navigation);
        }
    }
}
