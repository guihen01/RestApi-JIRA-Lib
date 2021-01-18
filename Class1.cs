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

        
    }



    public class Tools
    {

        /// <summary>
        ///  read a json formated file and convert to a text (string) formated file 
        /// </summary> 
        public static JObject ConvertJsontoString()
        {
            string path1;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("json file name (JSon format) to convert ?  ");
            Console.WriteLine("--------------------------------------------------");
            path1 = Console.ReadLine();
            Console.WriteLine("----------------------------------------------------------");

            // Get the current directory where we want to read the json file.
            //--------------------------------------------------------------
            string dir = Directory.GetCurrentDirectory();
            string path = dir + "/" + path1;

            //Read  the data under json format in a file 
            //----------------------------------------------------------------------------
            string Result;
            using (var tw = new StreamReader(path, true))
            {
                Result = tw.ReadLine();
                tw.Close();
            }

            //write to Console sous forme d'objet
            //---------------------------------------------------------------------------
            JObject Ob = JObject.Parse(Result);
            Console.WriteLine(Ob.ToString());
            Console.WriteLine("----------------------------------------------------------");

            // write the result in a text formated file
            //----------------------------------------------------------------------------
            //ecriture dans un fichier des données au format string
            string path3;
            Console.WriteLine("pahtname of json file (text format) to create ?  ");
            path3 = Console.ReadLine();
            Console.WriteLine("--------------------------------------------------");

            string path4;
            path4 = dir + "/" + path3;

            if (File.Exists(path4))
            {
                File.Delete(path4);
            }
            using (var tw1 = new StreamWriter(path4, true))
            {
                tw1.WriteLine(Ob.ToString());
                tw1.Close();
            }
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("json formated file : ¨{0} .txt created ", path4);
            Console.WriteLine("----------------------------------------------------------");

            //return object type . teh object returned is the json file formated as an object
            return (Ob);
        }


        /// <summary>
        ///  read a json formated file and convert to a text (string) formated file 
        /// </summary> 
        public static JObject ConvertJsontoString(string pathname, string filenameJson, string filenameTxt)
        {

            string Fullpath;
            // Use Combine again to add the file name to the path.
            Fullpath = System.IO.Path.Combine(pathname, filenameJson);

            //Read  the data under json format in a file 
            //----------------------------------------------------------------------------
            string Result;
            using (var tw = new StreamReader(Fullpath, true))
            {
                Result = tw.ReadLine();
                tw.Close();
            }

            //write to Console sous forme d'objet
            //---------------------------------------------------------------------------
            Console.WriteLine("----------------------------------------------------------");
            JObject Ob = JObject.Parse(Result);
            Console.WriteLine(Ob.ToString());
            Console.WriteLine("----------------------------------------------------------");

            // write the result in a text (string) formated file
            //----------------------------------------------------------------------------
            string Fullpath1;
            Fullpath1 = System.IO.Path.Combine(pathname, filenameTxt);

            if (File.Exists(Fullpath1))
            {
                File.Delete(Fullpath1);
            }
            using (var tw1 = new StreamWriter(Fullpath1, true))
            {
                tw1.WriteLine(Ob.ToString());
                tw1.Close();
            }
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("json formated file : ¨{0} .txt created ", Fullpath1);
            Console.WriteLine("----------------------------------------------------------");

            //return object type . teh object returned is the json file formated as an object
            return (Ob);
        }

        /// <summary>
        ///  read a json formated file and convert to a text (string) formated file 
        /// </summary> 
        public static JObject ConvertJsontoString(string fileJson, string fileTxt)
        {
            //Read  the data under json format in a file 
            //----------------------------------------------------------------------------
            string Result;
            using (var tw = new StreamReader(fileJson, true))
            {
                Result = tw.ReadLine();
                tw.Close();
            }

            JObject Ob = JObject.Parse(Result);

            // write the result in a text (string) formated file
            //----------------------------------------------------------------------------
            using (var tw1 = new StreamWriter(fileTxt, true))
            {
                tw1.WriteLine(Ob.ToString());
                tw1.Close();
            }

            //return object type . the object returned is the json file formated as an object
            return (Ob);
        }

    }
}





