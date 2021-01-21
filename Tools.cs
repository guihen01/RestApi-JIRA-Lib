using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

/// <summary>
///  Tools routines to deal with a json formated file or text (string) formated file 
/// </summary> 
namespace JiraLib
{
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
        /// 
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
        /// <param name="fileJson">  json file name and path  </param>
        /// <param name="fileTxt">  Txt file name and path  </param>
        /// <returns>  a JObject type (json file formated as an object)  </returns> 
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


        /// <summary>
        ///  read a json formated file (type JObject) and convert to a text (string) formated file 
        /// </summary> 
        /// <param name="fileJson">  json file name : format of the json file : JObject </param>
        /// <param name="fileTxt">  Txt file name   </param>
        /// <returns>  a JObject type (json file formated as an object of type JObject)  </returns> 
        public static JObject JsontJObjectToString(string fileJson, string fileTxt)
        {
            // Read  the data under json format in a file. The file must contain a JObject type of data
            //-----------------------------------------------------------------------------------------
            // The json file must be of a JObject type compatible          
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

        /// <summary>
        ///  read a json formated file (type JToken) and convert to a text (string) formated file 
        /// </summary> 
        /// <param name="fileJson">  json file name : format of the json file : JToken </param>
        /// <param name="fileTxt">  Txt file name   </param>
        /// <returns>  a JToken type (json file formated as an object of type JToken)  </returns> 
        public static JToken JsontJTokenToString(string fileJson, string fileTxt)
        {
            // Read  the data under json format in a file. The file must contain a JToken type of data
            //---------------------------------------------------------------------------------------
            // The json file must be of a JObject type compatible          
            //----------------------------------------------------------------------------
            string Result;
            using (var tw = new StreamReader(fileJson, true))
            {
                Result = tw.ReadLine();
                tw.Close();
            }

            JToken Ob = JToken.Parse(Result);

            // write the result in a text (string) formated file
            //----------------------------------------------------------------------------
            using (var tw1 = new StreamWriter(fileTxt, true))
            {
                tw1.WriteLine(Ob.ToString());
                tw1.Close();
            }

            //return object type . the object returned is the json file formated as JToken
            return (Ob);
        }

        /// <summary>
        ///  read a json from a file (type : JArray) and convert to a text (string) formated file 
        /// </summary> 
        /// <param name="fileJson">  json file name :   </param>
        /// <param name="fileTxt">  Txt file name   </param>
        /// <returns>  a JArray type (json file formated as an object of type JArray)  </returns> 
        public static JArray JsontArrayToString(string fileJson, string fileTxt)
        {
            // read JSON directly from a file . The file must contain a JArray type of data
            //------------------------------------------------------------------------------
            JArray Ob;
            using (StreamReader file = File.OpenText(fileJson))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                Ob = (JArray)JArray.ReadFrom(reader);
            }

            // write the result in a text (string) formated file
            using (var tw1 = new StreamWriter(fileTxt, true))
            {
                tw1.WriteLine(Ob.ToString());
                tw1.Close();
            }

            //return object type . the object returned is the json file formated as JArray
            return (Ob);
        }
    }
}
