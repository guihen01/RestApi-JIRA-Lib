﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace JiraLib
{

    /// <summary>
    ///  execute a GET http request on a Jira server with Rest API 
    ///  GEt results  
    ///  </summary>
    public static partial class Get
    {

        /// <summary>
        ///  Get list of username from a group 
        ///    
        ///  </summary>
        /// <returns>  string[] : an array of string which contains the list of the group's username  </returns>   
        public static async Task<string[]> GetUSernameFromGroup(string username, string password, string urlbase, string group)
        {
            string[] Users = new string[10000];

            string url;
            url = urlbase + "/rest/api/2/group/member?groupname=" + group;

            var client = new HttpClient();
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);

            var response = await client.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            string result = await response.Content.ReadAsStringAsync();
            client.Dispose();

            JObject Ob = JObject.Parse(result);

            // write list of group users username in file " List-username-from-group-{0}.json 
            string dir = Directory.GetCurrentDirectory();
            string path = dir + "/List-username-from-group-" + group + ".json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }

            // write list of group users username in file " List-username-from-group-{0}.txt 
            string path1 = dir + "/List-username-from-group-" + group + ".txt";
            if (File.Exists(path1))
            {
                File.Delete(path1);
            }
            using (var tw1 = new StreamWriter(path1, true))
            {
                tw1.WriteLine(Ob.ToString());
                tw1.Close();
            }

            //Extract list of username from json and store it in an array of strings
            //Query json whith LINQ  https://www.newtonsoft.com/json/help/html/QueryingLINQtoJSON.htm
            var postTitles =
               from p in Ob["values"]
               select (string)p["name"];

            int j = 0;
            foreach (var item in postTitles)
            {
                Users[j] = item;
                j++;
            }


            return Users;
        }

    }
}