using System;
using System.Collections.Generic;
using Entities;
using Xamarin.Forms;

namespace App_Pruebas.View
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            menuView.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                menuView.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
