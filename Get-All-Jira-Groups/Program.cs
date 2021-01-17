using System;
using JiraLib;
using System.Threading.Tasks;

namespace Test2_Get_All_Jira_Groups
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string username;
            string password;
            string pathurl;
             
            username = "dupont";
            password = "admin";
            pathurl = "http://localhost:8080";
             
            await Get.GetAllGroups(username, password, pathurl);
                        
        }
    }
}
