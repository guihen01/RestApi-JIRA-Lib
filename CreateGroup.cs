using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace Jiralib
{
    class Rootobject
    {
        public string name { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public Properties properties { get; set; }
        public bool additionalProperties { get; set; }
    }

    class Properties
    {
        public Name name { get; set; }
    }

    class Name
    {
        public string type { get; set; }
    }

    public static class CreateGroup1
    {
        public static async System.Threading.Tasks.Task CreateGroup()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Execute (Jira Server platform) REST API");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(" REf : https://docs.atlassian.com/software/jira/docs/api/REST/8.13.2/");
            Console.WriteLine("----------------------------------------------------------------------------");

            string url, url1;
            Console.WriteLine(" pathname complet du serveur Jira (URL) with port number ? ");
            Console.WriteLine("as : http://localhost:8080");
            Console.WriteLine("----------------------------------------------------------------------------");
            url1 = Console.ReadLine();

            Console.WriteLine("Create a Jira Group ");
            Console.WriteLine("name of the Jira Group ?");
            string GroupName;
            GroupName = Console.ReadLine();
            Console.WriteLine(" Groupname to create : {0}", GroupName);

            url = url1 + "/rest/api/2/group";

            Console.WriteLine(" URIs for Jira's REST API choosed to create a group {0} ", url);
            Console.WriteLine("------------------------------------------------------------------------");

            Rootobject R1 = new Rootobject();
            {
                R1.name = GroupName;
                R1.id = url1 + "/jira/REST/schema/add-group#";
                R1.title = GroupName;
                R1.type = "object";
                Properties R2 = new Properties();
                
                Name R3 = new Name();
                R3.type = "string";
                R1.additionalProperties = false;
            }

            var json = JsonConvert.SerializeObject(R1);


            var data = new StringContent(json, Encoding.UTF8, "application/json");

            string username;
            Console.WriteLine("user account in Jira for authentication");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" Jira username  ? ");
            username = Console.ReadLine();

            string password;
            Console.WriteLine(" Jira password  ? ");
            password = Console.ReadLine();

            //Send the request via Http protocol to the JIRA server & Get the response in a string (the string is Json formated)
            //------------------------------------------------------------------------------------------------------------------
            string result;
            result = await JiraLib.Http.GetHttpResponse(username, password, url);

            //wrtite to Console sous forme groupée
            //---------------------------------------------------------------------------
            Console.WriteLine(result);
            Console.WriteLine("----------------------------------------------------------");

            //wrtite to Console sous forme d'objet
            //---------------------------------------------------------------------------
            JObject Ob = JObject.Parse(result);
            Console.WriteLine(Ob.ToString());
            Console.WriteLine("----------------------------------------------------------");


            string dir = Directory.GetCurrentDirectory();
            string path = dir + "/Group-Response" + ".json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }
            Console.WriteLine("json formated file : Group-Response.json created ");
            Console.WriteLine("------------------------------------------------------------");

            //write the result sous forme d'objet in a file 
            // write the result in a text formated file
            //----------------------------------------------------------------------------
            //ecriture dans un fichier des données au format string

            string path1 = dir + "/Group-Response" + ".txt";
            if (File.Exists(path1))
            {
                File.Delete(path1);
            }
            using (var tw1 = new StreamWriter(path1, true))
            {
                tw1.WriteLine(Ob.ToString());
                tw1.Close();
            }
            Console.WriteLine("text formated file : Group-Response.txt created ");
            Console.WriteLine("----------------------------------------------------------");


        }




    }
}
