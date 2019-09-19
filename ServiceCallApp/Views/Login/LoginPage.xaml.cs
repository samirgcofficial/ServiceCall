using System;
using System.Collections.Generic;
using ServiceCallApp.ViewModel.Login;
using Xamarin.Forms;

namespace ServiceCallApp.Views.Login
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //animationView.IsVisible = true;
            BindingContext = new LoginViewModel();
            MyUserNumber.Text = "7676649751";
            MyPassword.Text = "welcome123";
        }
    }
}
