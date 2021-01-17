using System;
using JiraLib;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;   // needed for use with type : JObject

namespace Test3_Convert_Json_ToString
{
        class Program
        {
            static void Main(string[] args)
            {
                string fileJson;
                string fileTxt;
                JObject Ob;
                                 
                fileJson = "C:/C#Rest-API/Test-RestAPI-Jira-Lib/Test3-Convert-Json-ToString/bin/Debug/netcoreapp3.1/List-groups.json";
                fileTxt = "C:/C#Rest-API/Test-RestAPI-Jira-Lib/Test3-Convert-Json-ToString/bin/Debug/netcoreapp3.1/new4.txt";
                
                Ob = Tools.ConvertJsontoString(fileJson, fileTxt);        

            }
        }
}


