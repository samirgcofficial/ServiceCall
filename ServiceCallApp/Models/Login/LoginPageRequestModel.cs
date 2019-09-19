using System;
namespace ServiceCallApp.Models.Login
{
    public class LoginPageRequestModel
    {
        public string phone { get; set; }
        public string password { get; set; }

        public LoginPageRequestModel(string UserName, string Password)
        {
            phone = UserName;
            password = Password;
        }

    }
}
