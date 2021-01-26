using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using JiraLib;

namespace GetAllUsersFromGroupList
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string group;
            Console.WriteLine("name of group on which we will return the list of user's username ? ");
            group = Console.ReadLine();

            string[] Users;

            Users = await JiraLib.Get.GetUSernameFromGroup("guihen01", "admin", "http://localhost:8080", group);

            for (int i = 0; i < Users.Length; i++)
            { Console.WriteLine(" users name : {0} : ", Users[i]);
            }
        }           
    }
}
