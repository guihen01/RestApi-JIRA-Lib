using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
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
        ///  execute a GET http request on a Jira server with Rest API, to get all groups. 
        ///  GEt results as  json file 
        ///  </summary>
        public static async System.Threading.Tasks.Task GetAllGroups(string username, string password, string pathurl)
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Execute (Jira Server platform) REST API");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(" REf : Goto : https://docs.atlassian.com/software/jira/docs/api/REST/8.13.2/");
            Console.WriteLine("----------------------------------------------------------------------------");

            string url;
            url = pathurl + "/rest/api/2/groups/picker";
            Console.WriteLine(" URIs for Jira's REST API cchoosed to pick groups is : {0} ", url);
            Console.WriteLine("------------------------------------------------------------------------");

            var client = new HttpClient();


            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
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
            JObject o = JObject.Parse(result);
            Console.WriteLine(o.ToString());
            Console.WriteLine("----------------------------------------------------------");

            //var items = o.SelectTokens("$.[?(@.Country=='India')]");
            //foreach (var item in items)
            //   Console.WriteLine(item);

            //write the result sous forme groupée in a file 
            // write the result in a json formated file
            //----------------------------------------------------------------------------
            //ecriture dans un fichier des données au format Json
            // Get the current directory.

            string dir = Directory.GetCurrentDirectory();
            string path = dir + "/List-groups.json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }
            Console.WriteLine("json formated file : List-groups.json created ");
            Console.WriteLine("----------------------------------------------------------");

            //write the result sous forme d'objet in a file 
            // write the result in a text formated file
            //----------------------------------------------------------------------------
            //ecriture dans un fichier des données au format string

            string path1 = dir + "/List-groups.txt";
            if (File.Exists(path1))
            {
                File.Delete(path1);
            }
            using (var tw1 = new StreamWriter(path1, true))
            {
                tw1.WriteLine(o.ToString());
                tw1.Close();
            }
            Console.WriteLine("text formated file : List-groups.txt created ");
            Console.WriteLine("----------------------------------------------------------");
        }


        /// <summary>
        ///  execute a GET http request on a Jira server with Rest API, to get all members of a given group. 
        ///  GEt results as  json file and Text file
        ///  </summary>
        public static async System.Threading.Tasks.Task GetUSersFromGroup()
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

            string group;
            Console.WriteLine("name of the group for which members will be returned ?");
            group = Console.ReadLine();


            url = url1 + "/rest/api/2/group/member?groupname=" + group;

            Console.WriteLine(" URIs for Jira's REST API choosed to pick group's members is : {0} ", url);
            Console.WriteLine("------------------------------------------------------------------------");

            var client = new HttpClient();

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
            JObject o = JObject.Parse(result);
            Console.WriteLine(o.ToString());
            Console.WriteLine("----------------------------------------------------------");


            string dir = Directory.GetCurrentDirectory();
            string path = dir + "/List-users-from-group-" + group + ".json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }
            Console.WriteLine("json formated file : List-users-from-group-{0}.json created ", group);
            Console.WriteLine("------------------------------------------------------------");

            //write the result sous forme d'objet in a file 
            // write the result in a text formated file
            //----------------------------------------------------------------------------
            //ecriture dans un fichier des données au format string

            string path1 = dir + "/List-users-from-group-" + group + ".txt";
            if (File.Exists(path1))
            {
                File.Delete(path1);
            }
            using (var tw1 = new StreamWriter(path1, true))
            {
                tw1.WriteLine(o.ToString());
                tw1.Close();
            }
            Console.WriteLine("text formated file : List-users-from-group-{0}.txt created ", group);
            Console.WriteLine("----------------------------------------------------------");

        }

        /// <summary>
        ///  execute a GET http request on a Jira server with Rest API, to get all users details from all JIRA groups. 
        ///  GEt results as  json file and Text file and as an array of Objects list
        ///  </summary>
        public static async Task<List<GroupInfo>[]> GetAllUsersDetail(string username, string password, string urlbase)
        {
            //liste d'objets de type class Group qui  regroupe tous les groupes et  pour chaque groupe tous les usernames                        
            List<Group> Gr = new List<Group>();

            //-------------------------------------------------------------------------------------------------------------------------------------------
            // The below routine will get all groups & store All Jira groups in 2 files :List-groups.txt & List-groups.json in the current exec directory
            //-------------------------------------------------------------------------------------------------------------------------------------------
            await Get.GetAllGroups(username, password, urlbase);

            //extraction of the groups list from file : List-groups.json
            //----------------------------------------------------------
            string dir = Directory.GetCurrentDirectory();
            string path = dir + "/List-groups.json";
            if (File.Exists(path) != true)
            {
                Console.WriteLine("file doesnT exist");
            }

            //lecture dans un fichier des données au format Json
            //--------------------------------------------------
            string JsonResult;
            using (var tr = new StreamReader(path, true))
            {
                JsonResult = tr.ReadLine();
                tr.Close();
            }

            //Quey json (ref : https://www.newtonsoft.com/json/help/html/QueryJson.htm )
            JObject rss = JObject.Parse(JsonResult);

            //Query json whith LINQ  https://www.newtonsoft.com/json/help/html/QueryingLINQtoJSON.htm
            var postTitles =
               from p in rss["groups"]
               select (string)p["name"];

            //count the number of  groups
            int nbgroups = 0;
            foreach (var item in postTitles)
            {
                nbgroups++;
            }

            //--------------------------------------------------------------------------------------------
            // Get All Users details in each group  & returns a list of objects (objects of type GroupInfo 
            //--------------------------------------------------------------------------------------------
            List<GroupInfo>[] Data = new List<GroupInfo>[nbgroups];   //could have used postTitles.Count 
            int n = 0;
            foreach (var item in postTitles)
            {
                List<GroupInfo> Data1;
                Data1 = new List<GroupInfo>();

                //list of all users users details in each group 
                Data1 = await Get.GetUSersDetailFromGroup(username, password, urlbase, item);

                // ajout dun objet d'une liste de type GroupInfo  au tabeau de liste
                // add all users's details from a group in the list 
                Data[n] = Data1;
                n++;
            }

            return Data;
        }


    }
   
}





