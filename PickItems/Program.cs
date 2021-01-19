using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using JiraLib;

namespace Test5_Pick_Jira_Items
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
           //Returns a list of JIRA, users, groups, name, emailadress matching a specific string

           await JiraLib.Get.PickItems();     

        }
    }
}
