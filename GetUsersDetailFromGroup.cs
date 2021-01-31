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

namespace JiraLib
{
    /// <summary>
    /// users details in a JIRA group"
    /// </summary>
    public class GroupInfo
    {
        public string groupname { get; set; }
        public string username { get; set; }
        public string displayname { get; set; }
        public string email { get; set; }
        public string active { get; set; }
    }

    /// <summary>
    /// include methods to pick users details from a specific group
    /// </summary> 
    public static partial class Get
    {
        //---------------------------------------------------------------------------------------------------
        // The routine : GetUsersDetailFromGroup returns a list of objects (objects of type Group) List<GroupInfo>
        // & write result to file (Json style) : List-Details-from-group-{0}.txt" 
        // & write result to file (text file)  : List-accounts-from-group-{0}.txt"
        // Details are : username, full name, email, group , active user or not
        //---------------------------------------------------------------------------------------------------

        /// <summary>
        ///  Get list of users details from a group 
        /// </summary>
        /// <returns>  List<GroupInfo> : returns a list of objects (objects of type GroupInfo) List<GroupInfo>
        /// & write result to file (Json style) : List-Details-from-group-{0}.txt" 
        /// & write result to file (text file)  : List-accounts-from-group-{0}.txt "
        /// </returns>
        public static async Task<List<GroupInfo>> GetUSersDetailFromGroup(string username, string password, string urlbase, string group)
        {
            //liste d'objets de type class GroupInfo qui  regroupe tous les groupes et  pour chaque groupe tous les usernames 
            //---------------------------------------------------------------------------------------------------------------
            List<GroupInfo> GrList = new List<GroupInfo>();

            string url;
            url = urlbase + "/rest/api/2/group/member?groupname=" + group;

            //Send the request via Http protocol to the JIRA server & Get the response in a string (the string is Json formated)
            //------------------------------------------------------------------------------------------------------------------
            string result;
            result = await Http.GetHttpResponse(username, password, url);

            
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
