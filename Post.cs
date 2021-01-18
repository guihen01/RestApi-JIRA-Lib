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
}
