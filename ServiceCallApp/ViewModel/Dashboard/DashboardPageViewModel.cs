using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceCallApp.Models.Dashboard;
using ServiceCallApp.Networking;
using Xamarin.Forms;

namespace ServiceCallApp.ViewModel.Dashboard
{
    public class DashboardPageViewModel
    {
        public List<Datum> UserSection { get; set; }

        public DashboardPageViewModel()
        {
            UserSection = new List<Datum>();
           // GetCommonUserDetails();
        }
        internal async Task<DashboardPageResponseModel> GetCommonUserDetails()
        {
            string getId = Application.Current.Properties["GetUserId"].ToString();
            ServiceStatusResponse serviceStatusResponse = await ServiceClient.ServiceClientInstance.PostUserWithId(getId);
            try
            {
                if (serviceStatusResponse.theStatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await serviceStatusResponse.httpContent.ReadAsStringAsync();
                    var commonHomeModel = JsonConvert.DeserializeObject<DashboardPageResponseModel>(result);
                    return commonHomeModel;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
