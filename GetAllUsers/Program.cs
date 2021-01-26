using JiraLib;
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

using OfficeOpenXml;

using Jiralib;

namespace Get_All_Users
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
            List<Group> Data;

            Data = await GetAllUsers("guihen01", "admin", "http://localhost:8080");

            //List of all groups and users extracted :
            Console.WriteLine("Data extracted");
        }


        //-----------------------------------------------------------------------------------------
        //The routine : GetAllUsers returns a list of objects (objects of type Group) List<Group>
        //---------------------------------------------------------------------------------------
        static async Task<List<Group>> GetAllUsers(string username, string password, string urlbase)
        {
            //liste d'objets de type class Group qui  regroupe tous les groupes et  pour chaque groupe tous les usernames                        
            List<Group> Gr = new List<Group>();

            // The below routine will store All Jira groups in 2 files :List-groups.txt & List-groups.json in the current exec directory
            await Get.GetAllGroups("guihen01", "admin", "http://localhost:8080");

            //extraction of the groups list from file : List-groups.json
            string dir = Directory.GetCurrentDirectory();
            string path = dir + "/List-groups.json";
            if (File.Exists(path) != true)
            {
                Console.WriteLine("file doesnT exist");
            }
            //lecture dans un fichier des données au format Json
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

            int j = 0;
            string[] Users;
            foreach (var item in postTitles)
            {
                Console.WriteLine("group : {0} ",item);
                Group g1 = new Group();
                g1.groupname = item;

                //list of all users username in each group 
                //https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-return-a-value-from-a-task
                Users = await Task.Run(() => Get.GetUSernameFromGroup("guihen01", "admin", "http://localhost:8080", item));
                g1.Users = Users;

                Gr.Add(g1);  // ajout d<un objet de type groupe a la liste (add an object of type Group in the List)

            }
            
            // Store all results in an Excel file
            
            // If you use EPPlus in a noncommercial context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet worksheet;
            worksheet = excel.Workbook.Worksheets.Add("TestSheet1");
            
            FileInfo excelFile = new FileInfo("List-ALl-UsersGroups.xlsx");

            worksheet.Cells["A1"].Value = "Group";
            worksheet.Cells["B1"].Value = "Username";
            worksheet.Cells["A1:B1"].Style.Font.Bold = true;
            worksheet.Cells["A1:B1"].Style.Font.Size = 14;

            int pos = 2;  //ligne 2 du fichier excel
            string Range;
            for (int i = 0; i < Gr.Count; i++)  // we iterate on the number of groups
            {
                if (Gr[i].Users.Length != 0)
                {
                    for (int k = 0; k < Gr[i].Users.Length; k++)
                    {
                        Range = "A" + pos.ToString();
                        worksheet.Cells[Range].Value = Gr[i].groupname;
                        Range = "B" + pos.ToString();
                        worksheet.Cells[Range].Value = Gr[i].Users[k];
                        pos++;
                    }
                }
            }
            
            excel.SaveAs(excelFile);

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Data stored to  file : List-ALl-UsersGroups.xlsx");
            Console.WriteLine("--------------------------------------------------------------------");

            return Gr;
        }

    }
}
