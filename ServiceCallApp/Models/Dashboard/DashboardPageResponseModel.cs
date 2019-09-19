using System;
using System.Collections.Generic;

namespace ServiceCallApp.Models.Dashboard
{
    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class DashboardPageResponseModel
        {
        public List<Datum> data { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }
    
}
