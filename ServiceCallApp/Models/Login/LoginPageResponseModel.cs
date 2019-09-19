using System;
namespace ServiceCallApp.Models.Login
{
    public class Data
    {
        public int id { get; set; }
        public string username { get; set; }
    }
    public class LoginPageResponseModel
    {
        public Data data { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }
    
}
