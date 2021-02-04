using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAllIssuesPj1
{
    /// <summary>
    /// Class contains details for a JIRA Issue
    /// </summary>
    public class IssueInfos
    {
        public string Projectname;
        public string Key;
        public string ID;
        public string Type;
        public string Status;
        public string Priority;
        public string Resolution;
        public string Creatorname;
        public string Creatorfullname;
        public string Reportername;
        public string Reporterfullname;
        public string Assigneename;
        public string Assigneefullname;
    }
}
