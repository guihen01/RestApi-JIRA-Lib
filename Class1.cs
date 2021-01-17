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
    ///  execute a POST http request on a Jira server with Rest API 
    ///  </summary>
    public class Post
    {

        /// <summary>
        ///  execute a POST http request on a Jira server with Rest API, execute json file 
        ///  <list type="bullet">
        ///  <item><description><para><em>username : type string : username of a jira account:</em></para></description></item>
        /// <item><description><para><em>password : type string : password of a jira account:</em></para></description></item>
        /// <item><description><para><em>pathurl :type string : Jira URL endpoint, on which executing the http post request</em></para></description></item>
        /// <item><description><para><em>pathjson :type string : json pathname and file containing the POST request to execute </em></para></description></item>
        /// </list>
        /// </summary> 
        public static async System.Threading.Tasks.Task Post1(string username, string password, string pathurl, string pathjson, string result)
        {

            //REf : https://docs.atlassian.com/software/jira/docs/api/REST/8.13.2/"

            //pathname complet du fichier json
            //par exemple : C:/C#Rest-API/Curl/Test4-Post/test.json
            StreamReader sr = new StreamReader(pathjson);

            string json1;
            json1 = sr.ReadToEnd();

            var json = JsonConvert.SerializeObject(json1);
            var data = new StringContent(json1, Encoding.UTF8, "application/json");


            //var url = "http://localhost:8080/rest/api/2/issue";

            var client = new HttpClient();


            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);

            var response = await client.PostAsync(pathurl, data);

            // It would be better to make sure this request actually made it through

            result = await response.Content.ReadAsStringAsync();

            //close out the client
            client.Dispose();

            Console.WriteLine(result);
        }
    }


    /// <summary>
    ///  execute a GET http request on a Jira server with Rest API 
    ///  GEt results  
    ///  </summary>
    public class Get
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
    }
}





