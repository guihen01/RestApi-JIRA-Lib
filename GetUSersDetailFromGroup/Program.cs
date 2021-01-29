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
using System.Collections.Generic;


namespace Get.JIRA.usersGroups
{
    
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            List<GroupInfo> Data;

            Data = new List<GroupInfo>();

            string group;

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Execute (Jira Server platform) REST API");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(" REf : Goto : https://docs.atlassian.com/software/jira/docs/api/REST/8.13.2/");
            Console.WriteLine("----------------------------------------------------------------------------");

            string url;
            Console.WriteLine(" pathname complet du serveur Jira (URL) with port number ? ");
            Console.WriteLine("as : http://localhost:8080");
            Console.WriteLine("----------------------------------------------------------------------------");

            url = Console.ReadLine();
            Console.WriteLine(" URIs for Jira's REST API cchoosed to pick groups & users is : {0} ", url);
            Console.WriteLine("------------------------------------------------------------------------");

            string username;
            Console.WriteLine("user account in Jira for authentication");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" Jira username  ? ");
            username = Console.ReadLine();

            string password;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(" Jira password for this account and for authentication  ? ");
            password = Console.ReadLine();
            
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("name of group on which we will return the list of user's username ? ");
            group = Console.ReadLine();

            Data = await GetUSersDetailFromGroup(username, password, url, group);

            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("Data extracted to file (Json style) : List-Details-from-group-{0}.txt", group);
            Console.WriteLine("----------------------------------------------------------------------------");

            Console.WriteLine("Data extracted to file (text file) : List-accounts-from-group-{0}.txt", group);
            Console.WriteLine("----------------------------------------------------------------------------");

            Console.WriteLine("Data extracted (returned) to var List<GroupInfo> Data {0} ", Data);
            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine(" {0} accounts in {1} Jira group", Data.Count, group);
            Console.WriteLine("----------------------------------------------------------------");

            for (int i = 0; i < Data.Count; i++)
            {
                Console.WriteLine("Account :  {0} ", i);
                Console.WriteLine(" username : {0} ", Data[i].username);
                Console.WriteLine(" displayname : {0} ", Data[i].displayname);
                Console.WriteLine(" email : {0} ", Data[i].email);
                Console.WriteLine(" user actif ou non : {0} ", Data[i].active);
                Console.WriteLine("----------------------------------------------------------------");
            }

        }

        //---------------------------------------------------------------------------------------------------
        //The routine : GetUsersDetailFromGroup returns a list of objects (objects of type Group) List<GroupInfo>
        // & write result to file (Json style) : List-Details-from-group-{0}.txt" 
        // & write result to file (text file)  : List-accounts-from-group-{0}.txt"
        // Details are : username, full name, email, group , active user or not
        //---------------------------------------------------------------------------------------------------
        public static async Task<List<GroupInfo>> GetUSersDetailFromGroup(string username, string password, string urlbase, string group)
        {
            
            //liste d'objets de type class GroupInfo qui  regroupe tous les groupes et  pour chaque groupe tous les usernames 
            //---------------------------------------------------------------------------------------------------------------
            List<GroupInfo> GrList = new List<GroupInfo>();

            string url;
            url = urlbase + "/rest/api/2/group/member?groupname=" + group;

            using var client = new HttpClient();
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);

            var response = await client.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            string result = await response.Content.ReadAsStringAsync();
            client.Dispose();

            JObject Ob = JObject.Parse(result);

            // write list of group details in file " List-details-from-group-{0}.json 
            //-------------------------------------------------------------------------------
            string dir = Directory.GetCurrentDirectory();
            string path = dir + "/List-details-from-group-" + group + ".json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }

            // write list of group details in file " List-details-from-group-{0}.txt 
            //------------------------------------------------------------------------------
            string path1 = dir + "/List-details-from-group-" + group + ".txt";
            if (File.Exists(path1))
            {
                File.Delete(path1);
            }
            using (var tw1 = new StreamWriter(path1, true))
            {
                tw1.WriteLine(Ob.ToString());
                tw1.Close();
            }

            //Extract list of details from json and store it in an array of strings
            //----------------------------------------------------------------------
            //Query json whith LINQ  https://www.newtonsoft.com/json/help/html/QueryingLINQtoJSON.htm
            var postTitles =
               from p in Ob["values"]
               select (string)p["name"];

            var postemail =
               from p in Ob["values"]
               select (string)p["emailAddress"];

            var postname =
               from p in Ob["values"]
               select (string)p["displayName"];

            var postactive =
               from p in Ob["values"]
               select (string)p["active"];

            string[] Name = new string[postTitles.Count()];
            int nbusers = 0;
            int k = 0;
            foreach (var item in postTitles)
            {
                nbusers++;
                Name[k] = item;
                k++;
            }

            string[] Email = new string[postemail.Count()];
            k = 0;
            foreach (var item in postemail)
            {
                Email[k] = item;
                k++;
            }

            string[] Display = new string[postname.Count()];
            k = 0;
            foreach (var item in postname)
            {
                Display[k] = item;
                k++;
            }

            string[] Active = new string[postactive.Count()];
            k = 0;
            foreach (var item in postactive)
            {
                Active[k] = item;
                k++;
            }

           
            //remplissage des classes avec les informations
            //---------------------------------------------
            for (int i = 0; i < nbusers; i++)
            {
                GroupInfo Gr = new GroupInfo();
                Gr.groupname = group;
                Gr.username = Name[i];
                Gr.email = Email[i];
                Gr.displayname = Display[i];
                Gr.active = Active[i];
                // Add the object to the group List :
                GrList.Add(Gr);
            }

            // write list of group details in file " List-accounts-from-group-{0}.txt 
            //------------------------------------------------------------------------------
            path1 = dir + "/List-accounts-from-group-" + group + ".txt";
            if (File.Exists(path1))
            {
                File.Delete(path1);
            }

            using (var tw2 = new StreamWriter(path1, true))
            {
                for (int i = 0; i < GrList.Count; i++)
                {
                    tw2.WriteLine("----------------------------------------------------------------");
                    tw2.WriteLine("Account :  {0} ", i);
                    tw2.WriteLine(" username : {0} ", GrList[i].username);
                    tw2.WriteLine(" displayname : {0} ", GrList[i].displayname);
                    tw2.WriteLine(" email : {0} ", GrList[i].email);
                    tw2.WriteLine(" user actif ou non : {0} ", GrList[i].active);
                    tw2.WriteLine("----------------------------------------------------------------");
                }
                tw2.Close();
            }

            return GrList;
        }
    }
}
