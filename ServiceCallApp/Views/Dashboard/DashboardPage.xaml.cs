using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ServiceCallApp.Models.Dashboard;
using ServiceCallApp.ViewModel.Dashboard;
using ServiceCallApp.Views.AddFieldInformation;
using Xamarin.Forms;

namespace ServiceCallApp.Views.Dashboard
{
    public partial class DashboardPage : ContentPage
    {

        public DashboardPageResponseModel UserSection { get; set; }
        public DashboardPage()
        {
            InitializeComponent();
            BindingContext = new DashboardPageViewModel();
        }


        async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddFieldPage());
        }


        protected async override void OnAppearing()
        {
            //Load states
            base.OnAppearing();
            DashboardPageViewModel dashboardPageViewModel = new DashboardPageViewModel();
            await dashboardPageViewModel.GetCommonUserDetails();
            UserSection = await dashboardPageViewModel.GetCommonUserDetails();

            PositionsListItems.ItemsSource = UserSection.data;
            //foreach (var item in UserSection)
            //{
            //    PositionsListItems.ItemsSource = item.data;
            //}
        }
        //async void OnButtonClicked(object sender, EventArgs args)
        //{
        //    await label.RelRotateTo(360, 1000);
        //}
    }
}
