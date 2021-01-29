using Newtonsoft.Json;
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

using JiraLib;


namespace GetAllUsersDetail
{
    class Group
    {
        public string groupname;
        public string[] Users;
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            
            List<GroupInfo>[] Data;

            string username;
            string password;
            string urlbase;

            username = "test";
            password = "admin";
            urlbase = "http://localhost:8080";

            Data = await GetAllUsersDetail(username, password,urlbase);

            //List of all groups and users extracted :
            Console.WriteLine("Data extracted");


        }


        //-----------------------------------------------------------------------------------------
        //The routine : GetAllUsers returns a list of objects (objects of type Group) List<Group>
        //---------------------------------------------------------------------------------------
        static async Task<List<GroupInfo>[]> GetAllUsersDetail(string username, string password, string urlbase)
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
