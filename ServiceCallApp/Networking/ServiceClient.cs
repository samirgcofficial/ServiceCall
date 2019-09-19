using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceCallApp.Models;
using ServiceCallApp.Models.Login;

namespace ServiceCallApp.Networking
{
    public class ServiceClient
    {
        private static ServiceClient _ServiceClientInstance;

        public static ServiceClient ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new ServiceClient();
                return _ServiceClientInstance;
            }
        }
        private HttpClient client;
        private string UniversalURL;
        private string UniversalRegistrationURL;

        public ServiceClient()
        {
            client = new HttpClient();
            UniversalURL = Helpers.ConfigurationFile.ServerProdRegEndPoint.ToLower().ToString();
            client.BaseAddress = new Uri(UniversalURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //public async Task<List<LoginPageModel>> GetConsultancyInformationPosts(string UserName,string Password)
        //{

        //    LoginPageModel commonSignInModel = new LoginPageModel(UserName, Password);
        //    var json = JsonConvert.SerializeObject(commonSignInModel);
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("http://hrms-chat.herokuapp.com/");
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var requiredcontent = new StringContent(json, Encoding.UTF8, "application/json");
        //    var result = await client.PostAsync("api/users/authenticate", requiredcontent);
        //    string tokenXML = await result.Content.ReadAsStringAsync();
        //    var tokenXml = JsonConvert.DeserializeObject<List<LoginPageModel>>(tokenXML);
        //    return tokenXml;
        //  //  return new ServiceStatusResponse(result.StatusCode, result.Content);


        //    //return new List<ConsultancyModel>
        //    //{
        //    //    new ConsultancyModel { Title = "Turtle Bay Resort", Date = "JULY 24, 2015",  Image = "hawaii.jpg" },
        //    //    new ConsultancyModel { Title = "Grand Hotel", Date = "JULY 24, 2015", Image = "michigan.jpg" },
        //    //    new ConsultancyModel { Title = "Vista Verde", Date = "JULY 23, 2015", Image = "Colorado.jpg" },
        //    //    new ConsultancyModel { Title = "Woodloch Pines", Date = "JULY 23, 2015", Image = "hawaii.jpg" },
        //    //};
        //}

        public async Task<ServiceStatusResponse> GetRegisteredUser()
        {
            try
            {
                string requiredtoken = App.Current.Properties["SavedUserToken"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("JWT", requiredtoken);
                var result = client.GetAsync("api/users").Result;
                string tokenXML = result.Content.ReadAsStringAsync().Result;
                return new ServiceStatusResponse(result.StatusCode, result.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
     



        public async Task<ServiceStatusResponse> PostConsultancyInformationPosts(string username,string password)
        {
            try
            {
         


                LoginPageRequestModel commonSignInModel = new LoginPageRequestModel(username, password);
                var json = JsonConvert.SerializeObject(commonSignInModel);
                var requiredcontent = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("api/v1/user/login", requiredcontent);
                string tokenXML = result.Content.ReadAsStringAsync().Result;
                return new ServiceStatusResponse(result.StatusCode, result.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ServiceStatusResponse> PostUserWithId(string UserId)
        {
            try
            {
                SendUserId commonSignInModel = new SendUserId(UserId);
                var json = JsonConvert.SerializeObject(commonSignInModel);
                var requiredcontent = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("api/v1/user/project_for_user", requiredcontent);
                string tokenXML = result.Content.ReadAsStringAsync().Result;
                return new ServiceStatusResponse(result.StatusCode, result.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }




        public async Task<ServiceStatusResponse> PutRegisterUserWithNewIme(string requiredjson, string phonenumber)
        {
            try
            {
                //var client = new HttpClient();
                //client.BaseAddress = new Uri("https://phonelogin11.herokuapp.com/");
              //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var requiredcontent = new StringContent(requiredjson, Encoding.UTF8, "application/json");
                var result = await client.PutAsync("api/v1/user/" + phonenumber, requiredcontent);
                return new ServiceStatusResponse(result.StatusCode, result.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

    }
}
