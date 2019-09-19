using System;
namespace ServiceCallApp.Models.Login
{
    public class SendUserId
    {
        public string id { get; set; }


        public SendUserId(string getid)
        {

            id = getid;
        }

    }
}
