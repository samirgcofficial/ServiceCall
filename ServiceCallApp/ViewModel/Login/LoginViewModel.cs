using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using ServiceCallApp.Models;
using ServiceCallApp.Models.Login;
using ServiceCallApp.Networking;
using ServiceCallApp.Views.Dashboard;
using Xamarin.Forms;

namespace ServiceCallApp.ViewModel.Login
{
    public class LoginViewModel : BindableObject
    {
        private ObservableCollection<ConsultancyModel> _consultancyModels;

        public ObservableCollection<ConsultancyModel> ConsultancyModels
        {
            get { return _consultancyModels; }
            set
            {
                _consultancyModels = value;
                OnPropertyChanged();
            }
        }

        //SignIn Bindable Properties
        private string _username;
        private string _password;
        public string UserName
        {
            get => _username;
            set
            {
                if (value == _username) return;
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged();
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }


        public ICommand LoginCommand { get; }


        public LoginViewModel()
        {
            IsBusy = false;
            LoginCommand = new Command(async () => await LoadConsultancyList());
        }

        private async Task LoadConsultancyList()
        {
            IsBusy = true;
            await Task.Delay(500);
            ServiceStatusResponse getposts = await ServiceClient.ServiceClientInstance.PostConsultancyInformationPosts(UserName, Password);
            try
            {
                var result = getposts.httpContent.ReadAsStringAsync().Result;
                var tokenXml = JsonConvert.DeserializeObject<LoginPageResponseModel>(result);

                if (tokenXml.status =="success")
                {
                    //var str = tokenXml.token;
                    //str = str.Substring(4);
                    //Application.Current.Properties["UserName"] = UserName;
                    Application.Current.Properties["GetUserId"] = tokenXml.data.id;
                    //Application.Current.Properties["SavedUserToken"] = str;
                    //Application.Current.Properties["SavedUserRole"] = tokenXml.user.role;
                    Application.Current.MainPage = new NavigationPage(new DashboardPage());

                    IsBusy = false;

                }

            }
            catch(Exception e)
            {
                App.Current.MainPage.DisplayAlert("Error", e.Message, "Ok");

            }

                //     ConsultancyModels = new ObservableCollection<ConsultancyModel>(getposts);
        }
    }
}
