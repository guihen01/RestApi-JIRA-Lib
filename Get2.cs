using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace JiraLib
{

    /// <summary>
    ///  execute a GET http request on a Jira server with Rest API 
    ///  GEt results  
    ///  </summary>
    public static partial class Get
    {

        /// <summary>
        ///  //Returns a list of JIRA, users, groups, name, emailadress matching a specific string
        ///  GEt results as  json file 
        ///  </summary>
        public static async System.Threading.Tasks.Task PickItems()
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
            Console.WriteLine("extract a ist of all users, groups,Name, emailadress, containing this string   ");
            Console.WriteLine("string used to search username, Name or e-mail address, groups that will be returned ?");

            StringToMatch = Console.ReadLine();


            url = url1 + "/rest/api/2/groupuserpicker?query=" + StringToMatch;

            Console.WriteLine(" URIs for Jira's REST API choosed to pick all matching items {0} ", url);
            Console.WriteLine("------------------------------------------------------------------------");

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
            result = await Http.GetHttpResponse(username, password, url);

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
            string path = dir + "/List-items" + ".json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }
            Console.WriteLine("json formated file : List-items.json created ");
            Console.WriteLine("------------------------------------------------------------");

            //write the result sous forme d'objet in a file 
            // write the result in a text formated file
            //----------------------------------------------------------------------------
            //ecriture dans un fichier des données au format string

            string path1 = dir + "/List-items" + ".txt";
            if (File.Exists(path1))
            {
                File.Delete(path1);
            }
            using (var tw1 = new StreamWriter(path1, true))
            {
                tw1.WriteLine(Ob.ToString());
                tw1.Close();
            }
            Console.WriteLine("text formated file : List-items.txt created ");
            Console.WriteLine("----------------------------------------------------------");


        }

        /// <summary>
        /// Returns a list of users that match the search string 
        /// GEt results as  json file 
        /// </summary
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
            result = await Http.GetHttpResponse(username, password, url);

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

        /// <summary>
        /// Returns a list of all projects
        /// GEt results as  json file 
        /// </summary
        public static async System.Threading.Tasks.Task GetAllProjects()
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

            Console.WriteLine("extract a ist of all projects   ");

            url = url1 + "/rest/api/2/project";

            Console.WriteLine(" URIs for Jira's REST API choosed to pick all projects {0} ", url);
            Console.WriteLine("------------------------------------------------------------------------");

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
            result = await Http.GetHttpResponse(username, password, url);

            //wrtite to Console sous forme groupée
            //---------------------------------------------------------------------------
            Console.WriteLine(result);
            Console.WriteLine("----------------------------------------------------------");

            //wrtite to Console sous forme d'objet
            //---------------------------------------------------------------------------
            JArray Ob = JArray.Parse(result);
            Console.WriteLine(Ob.ToString());
            Console.WriteLine("----------------------------------------------------------");


            string dir = Directory.GetCurrentDirectory();
            string path = dir + "/List-projects" + ".json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }
            Console.WriteLine("json formated file : List-projects.json created ");
            Console.WriteLine("------------------------------------------------------------");

            //write the result sous forme d'objet in a file 
            // write the result in a text formated file
            //----------------------------------------------------------------------------
            //ecriture dans un fichier des données au format string

            string path1 = dir + "/List-projects" + ".txt";
            if (File.Exists(path1))
            {
                File.Delete(path1);
            }
            using (var tw1 = new StreamWriter(path1, true))
            {
                tw1.WriteLine(Ob.ToString());
                tw1.Close();
            }
            Console.WriteLine("text formated file : List-projects.txt created ");
            Console.WriteLine("----------------------------------------------------------");


        }


        /// <summary>
        /// Returns informations on Jra Server
        /// GEt results as  json file 
        /// </summary
        public static async System.Threading.Tasks.Task GetServerInfo()
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

            Console.WriteLine("extract list of informations about the Jira server  ");

            url = url1 + "/rest/api/2/serverInfo";

            Console.WriteLine(" URIs for Jira's REST API choosed to pick Jira Infos {0} ", url);
            Console.WriteLine("------------------------------------------------------------------------");

            
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
            result = await Http.GetHttpResponse(username, password, url);

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
            string path = dir + "/List-infos" + ".json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }
            Console.WriteLine("json formated file : List-infos.json created ");
            Console.WriteLine("------------------------------------------------------------");

            //write the result sous forme d'objet in a file 
            // write the result in a text formated file
            //----------------------------------------------------------------------------
            //ecriture dans un fichier des données au format string

            string path1 = dir + "/List-infos" + ".txt";
            if (File.Exists(path1))
            {
                File.Delete(path1);
            }
            using (var tw1 = new StreamWriter(path1, true))
            {
                tw1.WriteLine(Ob.ToString());
                tw1.Close();
            }
            Console.WriteLine("text formated file : List-infos.txt created ");
            Console.WriteLine("----------------------------------------------------------");

            
        }

    }
}
               