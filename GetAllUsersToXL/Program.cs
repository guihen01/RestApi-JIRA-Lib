using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using OfficeOpenXml;
using Jiralib;

namespace GetAl
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<JiraLib.Group> Data;

            Data = await JiraLib.Get1.GetAllUsersToXL("dupont", "admin", "http://localhost:8080");

            //List of all groups and users extracted :
            Console.WriteLine("Data extracted");
        }


    }
}