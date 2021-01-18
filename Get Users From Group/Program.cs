using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using JiraLib;

namespace Get_Users_From_Group
{
    class Program
    {
        
        static async System.Threading.Tasks.Task Main(string[] args)
        {

             await Get.GetUSersFromGroup();
        }
    }
}

