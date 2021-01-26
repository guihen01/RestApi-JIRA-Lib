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

namespace GetAllUsersFromGroupList
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string group;
            Console.WriteLine("name of group on which we will return the list of user's username ? ");
            group = Console.ReadLine();
            
            await GetUSernameFromGroup("guihen01","admin","http://localhost:8080",group);
        }

        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/async-return-types
        static async Task<string[]> GetUSernameFromGroup(string username, string password, string urlbase, string group)
        {
                      
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


            int nbusers = 0;
            foreach (var item in postTitles)
            {
              nbusers++;
            }
            
            string[] Users = new string[nbusers];
            int k = 0;
            foreach (var item in postTitles)
            {
                Users[k] = item;
                k++;
            }


            return Users;
        }


    }
}
