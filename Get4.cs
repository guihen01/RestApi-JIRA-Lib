using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;

namespace JiraLib
{
    /// <summary>
    ///  execute a GET http request on a Jira server with Rest API 
    ///  GEt results  
    ///  </summary>
    public static partial class Get
    {
        //------------------------------------------------------------------------------------------------------------
        //The routine : GetUnrIssuesPj returns a list of  all non resolved issues in a project
        /// <summary>
        ///  execute a GET http request on a Jira server with Rest API, to get all non resolved issues from a JIRA project. 
        ///  Write results to an Excel file 
        ///  </summary>
        ///  <param name="username"> username </param>
        ///  <param name="password"> password </param>
        ///  <param name="urlbase"> url of the Jira server ( ie : http://localhost:8080 )</param>
        ///  <param name="projectname"> project name </param>
        ///  <param name="Writeconsole"> Boolean value, if true, details and informations are writed to console screen </param>

        //---------------------------------------------------------------------------------------------------------------
        public static async Task GetUnrIssuesPj(string username, string password, string urlbase, string projectname, Boolean Writeconsole)
        {
            if (Writeconsole)
            {
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("Execute (Jira Server platform) REST API");
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine(" REf : Goto : https://docs.atlassian.com/software/jira/docs/api/REST/8.13.2/");
                Console.WriteLine("----------------------------------------------------------------------------");
            }

            string url;
            url = urlbase + "/rest/api/2/search?jql=project=" + projectname;

            if (Writeconsole)
            {
                Console.WriteLine(" URIs for Jira's REST API cchoosed to pick issues from project : {0} is : {1} ", projectname, url);
                Console.WriteLine("------------------------------------------------------------------------------------------------");
            }

            //Send the request via Http protocol to the JIRA server & Get the response in a string (the string is Json formated)
            //------------------------------------------------------------------------------------------------------------------
            string result;
            result = await Http.GetHttpResponse(username, password, url);


            //wrtite to Console sous forme groupée
            //---------------------------------------------------------------------------
            if (Writeconsole)
            {
                Console.WriteLine(result);
                Console.WriteLine("----------------------------------------------------------");
            }

            JObject Ob;
            Ob = JObject.Parse(result);

            //wrtite to Console sous forme d'objet
            //---------------------------------------------------------------------------
            if (Writeconsole)
            {
                Console.WriteLine(Ob.ToString());
                Console.WriteLine("----------------------------------------------------------");
            }

            //write the result sous forme groupée in a file 
            // write the result in a json formated file
            //----------------------------------------------------------------------------
            //ecriture dans un fichier des données au format Json
            // Get the current directory.

            string dir = Directory.GetCurrentDirectory();
            string path = dir + "/List-issues-" + projectname + ".json";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(result.ToString());
                tw.Close();
            }

            if (Writeconsole)
            {
                Console.WriteLine("json formated file : List-issues-{0}.json created ", projectname);
                Console.WriteLine("--------------------------------------------------------------");
            }

            //write the result sous forme groupée in a file 
            // write the result in a text formated file
            //----------------------------------------------------------------------------
            //ecriture dans un fichier des données au format string

            string path1 = dir + "/List-issues-" + projectname + ".txt";
            if (File.Exists(path1))
            {
                File.Delete(path1);
            }
            using (var tw1 = new StreamWriter(path1, true))
            {
                tw1.WriteLine(Ob.ToString());
                tw1.Close();
            }

            if (Writeconsole)
            {
                Console.WriteLine("text formated file :  List-issues-{0}.txt created ", projectname);
                Console.WriteLine("----------------------------------------------------------");
            }

            // Get the number of issues from the project stored in the json JObject Ob
            //----------------------------------------------------------------------
            int NumberOfIssues = 0;
            NumberOfIssues = GetNumberIssue(Ob, Writeconsole);

            // Get all issues details of the project, stored in the JObject variable : Ob
            //--------------------------------------------------------------------------
            JiraLib.Type.IssueInfos[] Data2;
            Data2 = GetProjectIssues(projectname, Ob, NumberOfIssues);

            // only unresolved issues are returned
            //----------------------------------------------------------------------------
            JiraLib.Type.IssueInfos[] Data3 = new JiraLib.Type.IssueInfos[NumberOfIssues];
            int j = 0;
            for (int i = 0; i < NumberOfIssues; i++)
            {
                if (Data2[i].Resolution == "Unresolved ")
                {
                    Data3[j] = Data2[i];
                    j++;
                }
            }

            if (j != 0)
            {
                // only unresolved issues are returned
                JiraLib.Type.IssueInfos[] Data4 = new JiraLib.Type.IssueInfos[j];
                for (int i = 0; i < j; i++)
                {
                    Data4[i] = Data3[i];
                }
                //Write results for unresolved issues to a EXcel file 
                //------------------------------------------------------------------------
                WrPrIssuesToXL(Data4, projectname, NumberOfIssues);

                if (Writeconsole)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" {0} issues are unresolved in this project", j);
                    Console.WriteLine(" ");
                }
            }
            else
            {
                if (Writeconsole)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("All issues are resolved . No unresolved issues in this project");
                    Console.WriteLine(" ");
                }
            }
        }

        /// <summary>
        /// Get all issues details in a project. Get from the json JObject Ob parameter 
        /// </summary>
        /// <param name="projectname"> project name </param>
        /// <param name="Ob"> Json JObject format variable. It must contain all issues details in a project, stored in a JOBject format </param>
        /// <param name="NumberOfIssues"> number of issues un the project </param> 
        /// <returns> IssueInfos[] Array of all Issues, inside the project </returns>
        public static JiraLib.Type.IssueInfos[] GetProjectIssues(string projectname, JObject Ob, int NumberOfIssues)
        {

            // get all issues key 
            //----------------------------------------
            string[] KeyField = new string[NumberOfIssues];
            var key =
              from p in Ob["issues"]
              select (string)p["key"];

            int k = 0;
            foreach (var item in key)
            {
                //Console.WriteLine(item);
                KeyField[k] = item;
                k++;
            }

            // get all issues id 
            //-----------------------------------------
            string[] IdField = new string[NumberOfIssues];
            var id =
              from p in Ob["issues"]
              select (string)p["id"];

            k = 0;
            foreach (var item in id)
            {
                //Console.WriteLine(item);
                IdField[k] = item;
                k++;
            }

            // get all issues type 
            //-----------------------------------------
            string[] TypeField = new string[NumberOfIssues];
            var type =
              from p in Ob["issues"]
              select (string)p["fields"]["issuetype"]["name"];

            k = 0;
            foreach (var item in type)
            {
                //Console.WriteLine(item);
                TypeField[k] = item;
                k++;
            }

            // get all issues creator username (The username creator of the issue)
            //-----------------------------------------------------------
            string[] CreatorField = new string[NumberOfIssues];
            var creator =
              from p in Ob["issues"]
              select (string)p["fields"]["creator"]["name"];

            k = 0;
            foreach (var item in creator)
            {
                //Console.WriteLine(item);
                CreatorField[k] = item;
                k++;
            }

            // get all issues creator Displayname ( The display full name of the creator of the issue)
            //--------------------------------------------------------------------------------
            string[] CreatorDisplayField = new string[NumberOfIssues];
            var display =
              from p in Ob["issues"]
              select (string)p["fields"]["creator"]["displayName"];

            k = 0;
            foreach (var item in display)
            {
                //Console.WriteLine(item);
                CreatorDisplayField[k] = item;
                k++;
            }

            // get all issues Reporters ( The reporter username of the issues)
            //--------------------------------------------------------------------------------
            string[] ReporterNameField = new string[NumberOfIssues];
            var reporter =
              from p in Ob["issues"]
              select (string)p["fields"]["reporter"]["name"];

            k = 0;
            foreach (var item in reporter)
            {
                //Console.WriteLine(item);
                ReporterNameField[k] = item;
                k++;
            }

            // get all issues Reporters displayname (The reporter displayname of the issue)
            //--------------------------------------------------------------------------------
            string[] ReporterDisplayField = new string[NumberOfIssues];
            var reporterDisplay =
              from p in Ob["issues"]
              select (string)p["fields"]["reporter"]["displayName"];

            k = 0;
            foreach (var item in reporterDisplay)
            {
                ReporterDisplayField[k] = item;
                k++;
            }

            // get all issues assignee username (The assignee username of the issue)
            //--------------------------------------------------------------------------------

            string[] AssigneeNameField = new string[NumberOfIssues];
            var assigneeName =
              from p in Ob["issues"]
                  //where p.HasValues
              select p["fields"]["assignee"];

            k = 0;
            //Console.WriteLine(" List of assignee username : ");
            foreach (var item in assigneeName)
            {
                if (item.HasValues)
                {
                    AssigneeNameField[k] = item.Value<string>("name");
                }
                else
                {
                    AssigneeNameField[k] = "Unassigned ";
                }

                k++;
            }

            // get all issues assignee displayname (The assignee displayname of the issue)
            //--------------------------------------------------------------------------------
            string[] AssigneeDisplayField = new string[NumberOfIssues];
            var assigneeDisplay =
              from p in Ob["issues"]
              select p["fields"]["assignee"];

            k = 0;
            foreach (var item in assigneeDisplay)
            {
                if (item.HasValues)
                {
                    AssigneeDisplayField[k] = item.Value<string>("displayName");
                }
                else
                {
                    AssigneeDisplayField[k] = "Unassigned ";
                }

                k++;
            }


            // get all issues status resolution 
            //-----------------------------------------
            string[] ResolutionField = new string[NumberOfIssues];
            var resolution =
              from p in Ob["issues"]
              select p["fields"]["resolution"];

            k = 0;
            foreach (var item in resolution)
            {
                if (item.HasValues)
                {
                    ResolutionField[k] = item.Value<string>("name");
                }
                else
                {
                    ResolutionField[k] = "Unresolved ";
                }

                k++;
            }

            // get all issues status
            //-----------------------------------------
            string[] StatusField = new string[NumberOfIssues];
            var status =
              from p in Ob["issues"]
              select p["fields"]["status"];

            k = 0;
            foreach (var item in status)
            {
                if (item.HasValues)
                {
                    StatusField[k] = item.Value<string>("name");
                }
                else
                {
                    StatusField[k] = "no status";
                }

                k++;
            }

            JiraLib.Type.IssueInfos[] Data2 = new JiraLib.Type.IssueInfos[NumberOfIssues];

            for (int i = 0; i < NumberOfIssues; i++)
            {
                JiraLib.Type.IssueInfos Iss = new JiraLib.Type.IssueInfos();
                Iss.Projectname = projectname;
                Iss.Key = KeyField[i];
                Iss.ID = IdField[i];
                Iss.Type = TypeField[i];
                Iss.Status = StatusField[i];
                Iss.Resolution = ResolutionField[i];
                Iss.Assigneename = AssigneeNameField[i];
                Iss.Assigneefullname = AssigneeDisplayField[i];
                Iss.Creatorname = CreatorField[i];
                Iss.Creatorfullname = CreatorDisplayField[i];
                Iss.Reportername = ReporterNameField[i];
                Iss.Reporterfullname = ReporterDisplayField[i];

                Data2[i] = Iss;
            }

            return Data2;
        }

        /// <summary>
        /// Write to Excel file all the issues (with details) which belong to a project 
        /// </summary>
        /// <param name="Data2"> All Issues details contained in a project </param>
        /// <param name="projectname"> project name </param>
        /// <param name="NumberOfIssues"> number of issues in the project  </param>
        public static void WrPrIssuesToXL(JiraLib.Type.IssueInfos[] Data2, string projectname, int NumberOfIssues)
        {

            //-------------------------------------------------------------------------------------
            // Store all results in an Excel file
            //-------------------------------------------------------------------------------------
            // If you use EPPlus in a noncommercial context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet worksheet;
            worksheet = excel.Workbook.Worksheets.Add("Sheet1");

            FileInfo excelFile;

            string FileName = "List-All-Issues-Project-" + projectname + ".xlsx";
            if (File.Exists(FileName) == true)
            {
                File.Delete(FileName);
            }
            excelFile = new FileInfo(FileName);

            worksheet.Cells["A1"].Value = "Project name";
            worksheet.Cells["B1"].Value = "Issue key";
            worksheet.Cells["C1"].Value = "Issue Id";
            worksheet.Cells["D1"].Value = "Issue type";
            worksheet.Cells["E1"].Value = "Issue status";
            worksheet.Cells["F1"].Value = "Resolution";
            worksheet.Cells["G1"].Value = "Assignee username";
            worksheet.Cells["H1"].Value = "Assignee full name";
            worksheet.Cells["I1"].Value = "Reporter username";
            worksheet.Cells["J1"].Value = "Reporter full name";
            worksheet.Cells["K1"].Value = "Creator username";
            worksheet.Cells["L1"].Value = "Creator full name";

            worksheet.Cells["A1:L1"].Style.Font.Bold = true;
            worksheet.Cells["A1:L1"].Style.Font.Size = 14;

            int pos = 2;  //ligne 2 du fichier excel

            string Range;
            for (int i = 0; i < Data2.Length; i++)
            {
                //var row =
                //from p in Data2[i]
                // select new { p.Projectname, p.Key ,p.ID, p.Type, p.Status, p.Resolution, p.Assigneename, p.Assigneefullname, p.Reportername, p.Reporterfullname,p.Creatorname, p.Creatorfullname};

                Range = "A" + pos.ToString();
                worksheet.Cells[Range].Value = Data2[i].Projectname;
                Range = "B" + pos.ToString();
                worksheet.Cells[Range].Value = Data2[i].Key;
                Range = "C" + pos.ToString();
                worksheet.Cells[Range].Value = Data2[i].ID;
                Range = "D" + pos.ToString();
                worksheet.Cells[Range].Value = Data2[i].Type;
                Range = "E" + pos.ToString();
                worksheet.Cells[Range].Value = Data2[i].Status;
                Range = "F" + pos.ToString();
                worksheet.Cells[Range].Value = Data2[i].Resolution;
                Range = "G" + pos.ToString();
                worksheet.Cells[Range].Value = Data2[i].Assigneename;
                Range = "H" + pos.ToString();
                worksheet.Cells[Range].Value = Data2[i].Assigneefullname;
                Range = "I" + pos.ToString();
                worksheet.Cells[Range].Value = Data2[i].Reportername;
                Range = "J" + pos.ToString();
                worksheet.Cells[Range].Value = Data2[i].Reporterfullname;
                Range = "K" + pos.ToString();
                worksheet.Cells[Range].Value = Data2[i].Creatorname;
                Range = "L" + pos.ToString();
                worksheet.Cells[Range].Value = Data2[i].Creatorfullname;

                pos++;

            }

            excel.SaveAs(excelFile);

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Data stored to  file : {0} ", FileName);
            Console.WriteLine("--------------------------------------------------------------------");
        }

        /// <summary>
        /// Get the number of issues in a project
        /// </summary>
        /// <param name="Ob"></param>
        /// <returns></returns>
        public static int GetNumberIssue(JObject Ob, Boolean Writeconsole)
        {
            //Query json whith LINQ to get the number of issues in the project 
            // https://www.newtonsoft.com/json/help/html/QueryingLINQtoJSON.htm
            //Number of issues in the project
            //-----------------------------------------------------------
            string Nbissues;
            Nbissues = (string)Ob["total"];

            if (Writeconsole)
            {
                Console.WriteLine(" number of issues in the project : {0} : ", Nbissues);
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(" ");
            }

            int NumbIssues;
            NumbIssues = Convert.ToInt32(Nbissues);

            return NumbIssues;
        }

    }
}


    

