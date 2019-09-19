using System;
using System.Collections.Generic;
using System.Net.Http;
using Plugin.Media;
using Plugin.Media.Abstractions;
using ServiceCallApp.ViewModel.AddFieldInformation;
using Xamarin.Forms;

namespace ServiceCallApp.Views.AddFieldInformation
{
    public partial class AddFieldPage : ContentPage
    {
        public AddFieldPage()
        {
            InitializeComponent();
            BindingContext = new AddFieldRequestVIewModel();
         
        }
        async void OnButtonClicked(object sender, EventArgs args)
        {
            App.Current.MainPage.DisplayAlert("Sucess", "Thanks file Uploaded", "Ok");
        }
    }
}