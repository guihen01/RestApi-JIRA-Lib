# GetUnrIssuesPj() : method

 
 [![JIRA.GetAll.IssuesInPj on fuget.org](https://www.fuget.org/packages/JIRA.GetAll.IssuesInPj/badge.svg)](https://www.fuget.org/packages/JIRA.GetAll.IssuesInPj)
[![Build status](https://ci.appveyor.com/api/projects/status/t25pekb23qqorbym?svg=true)](https://ci.appveyor.com/project/guihen01/getallissuespj)
[![NuGet](https://img.shields.io/nuget/v/JIRA.GetAll.IssuesInPj.svg)](https://www.nuget.org/packages/JIRA.GetAll.IssuesInPj/)

. returns a list of all non resolved issues in a project. Write them in a Excel file


https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/Capture-GetUnrresokvedIssues.PNG
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/Capture-GetUnrresokvedIssues.PNG "Logo Title Text 1"))

# Arguments of the method

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetUnrIssuesPj/GetUnrIssuesPj-def.GIF
![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetUnrIssuesPj/GetUnrIssuesPj-def.GIF  "Logo Title Text 1"))

# How to use

1. Download the nuget package at : https://www.nuget.org/packages/RestAPI-JIRA-Lib/
2. USe Visual Studio or tool that use Nuget 
3. in your c# code use the method GetUnrIssuesPj()
4. include the reference :   using JiraLib;

https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture4.PNG
![alt text]( https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture4.PNG "Logo Title Text 1")

5. use : await Get.GetUnrIssuesPj(username, password, urlbase, projectname, Writeconsole);

method is packed and assembled in the dll : and included in the Get class

![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetUnrIssuesPj/GetUnrIssuesPj-inLib.GIF "Logo Title Text 1")

 ![alt text](  "Logo Title Text 1")
