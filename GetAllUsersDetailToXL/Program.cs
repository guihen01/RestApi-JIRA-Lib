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

using JiraLib;

namespace GetAllUsersDetailToXL
{
    class Program
    {
        static async Task Main(string[] args)
        {

            List<GroupInfo>[] Data;

            string username;
            string password;
            string urlbase;

            username = "dupont";
            password = "admin";
            urlbase = "http://localhost:8080";

            Data = await GetAllUsersDetailToXL(username, password, urlbase);

            //List of all groups and users extracted :
            Console.WriteLine("Data extracted");


        }

        //------------------------------------------------------------------------------------------------------------
        //The routine : GetAllUsersDetailToXL returns a list of objects (objects of type GroupInfo) List<GroupInfo> 
        /// <summary>
        ///  execute a GET http request on a Jira server with Rest API, to get all users details from all JIRA groups. 
        ///  Write results to an Excel file 
        ///  </summary>
        
        //---------------------------------------------------------------------------------------------------------------
        static async Task<List<GroupInfo>[]> GetAllUsersDetailToXL(string username, string password, string urlbase)
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


            //-------------------------------------------------------------------------------------
            // Store all results in an Excel file
            //-------------------------------------------------------------------------------------
            // If you use EPPlus in a noncommercial context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet worksheet;
            worksheet = excel.Workbook.Worksheets.Add("TestSheet1");

            FileInfo excelFile;
            try
            {
                string na = "List-ALl-UsersGroups.xlsx";
                if (File.Exists(na) == true)
                {   File.Delete(na);
                }
                excelFile = new FileInfo("List-ALl-UsersGroups.xlsx");
 
              worksheet.Cells["A1"].Value = "Group";
              worksheet.Cells["B1"].Value = "Username";
              worksheet.Cells["C1"].Value = "Displayname";
              worksheet.Cells["D1"].Value = "Email adress";
              worksheet.Cells["E1"].Value = "Active status";
              worksheet.Cells["A1:E1"].Style.Font.Bold = true;
              worksheet.Cells["A1:E1"].Style.Font.Size = 14;
             
              int pos = 2;  //ligne 2 du fichier excel

              string Range;
              for (int i = 0; i < Data.Length; i++)
              {
                var row =
                    from p in Data[i]
                    select new { p.groupname, p.username, p.displayname, p.email, p.active };

                foreach (var item in row)
                {
                    Range = "A" + pos.ToString();
                    worksheet.Cells[Range].Value = item.groupname;
                    Range = "B" + pos.ToString();
                    worksheet.Cells[Range].Value = item.username;
                    Range = "C" + pos.ToString();
                    worksheet.Cells[Range].Value = item.displayname;
                    Range = "D" + pos.ToString();
                    worksheet.Cells[Range].Value = item.email;
                    Range = "E" + pos.ToString();
                    worksheet.Cells[Range].Value = item.active;
                    pos++;
                }
              }

              excel.SaveAs(excelFile);

              Console.WriteLine("--------------------------------------------------------------------");
              Console.WriteLine("Data stored to  file : List-ALl-UsersGroups.xlsx");
              Console.WriteLine("--------------------------------------------------------------------");
            }

            catch (IOException e)
            {
                Console.WriteLine("Error occurred: {0}", e.Message);
            }
            catch (System.InvalidOperationException e)
            {
                Console.WriteLine("Error occurred: {0}", e.Message);
            }

            return Data;
        }
    }

}

    

