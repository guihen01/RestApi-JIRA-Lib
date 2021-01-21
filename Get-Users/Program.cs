using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using JiraLib;

namespace Get_users
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //Returns a list of JIRA, users, groups, name, emailadress matching a specific string
            //Kind of regex matching and grep search

            await FindUsers();

        }

        public static async System.Threading.Tasks.Task FindUsers()
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

            string StringToMatch;
            Console.WriteLine("Returns a list of users that match the search string   ");
            Console.WriteLine("string used to search username ?");

            StringToMatch = Console.ReadLine();


            url = url1 + "/rest/api/2/user/search?username=" + StringToMatch;

            Console.WriteLine(" URIs for Jira's REST API choosed to pick all matching items {0} ", url);
            Console.WriteLine("------------------------------------------------------------------------");

            using var client = new HttpClient();

            string user;
            Console.WriteLine("user account in Jira for authentication");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" Jira username  ? ");
            user = Console.ReadLine();

            string password;
            Console.WriteLine(" Jira password  ? ");
            password = Console.ReadLine();


            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);

            var response = await client.GetAsync(url);
            Console.WriteLine(response.StatusCode);

            // It would be better to make sure this request actually made it through

            string result = await response.Content.ReadAsStringAsync();

            //close out the client
            client.Dispose();

            //wrtite to Console sous forme groupée
            //---------------------------------------------------------------------------
            Console.WriteLine(result);
            Console.WriteLine("----------------------------------------------------------");

            //wrtite to Console sous forme d'objet
            //---------------------------------------------------------------------------
            JToken Ob = JToken.Parse(result);
            Console.WriteLine(Ob.ToString());
            Console.WriteLine("----------------------------------------------------------");

            string dir = Directory.GetCurrentDirectory();
            string path = dir + "/List-users" + ".json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }
            Console.WriteLine("json formated file : List-users.json created ");
            Console.WriteLine("------------------------------------------------------------");

            //write the result sous forme d'objet in a file 
            // write the result in a text formated file
            //----------------------------------------------------------------------------
            //ecriture dans un fichier des données au format string

            string path1 = dir + "/List-users" + ".txt";
            if (File.Exists(path1))
            {
                File.Delete(path1);
            }
            using (var tw1 = new StreamWriter(path1, true))
            {
                tw1.WriteLine(Ob.ToString());
                         //tw1.WriteLine(result);
                tw1.Close();
            }
            Console.WriteLine("text formated file : List-users.txt created ");
            Console.WriteLine("----------------------------------------------------------");

            
        }
    }
}
