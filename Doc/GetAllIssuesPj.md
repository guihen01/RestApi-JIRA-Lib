# GetAllIssuesPj() : method
 
 [![JIRA.GetAll.IssuesInPj on fuget.org](https://www.fuget.org/packages/JIRA.GetAll.IssuesInPj/badge.svg)](https://www.fuget.org/packages/JIRA.GetAll.IssuesInPj)
[![Build status](https://ci.appveyor.com/api/projects/status/t25pekb23qqorbym?svg=true)](https://ci.appveyor.com/project/guihen01/getallissuespj)
[![NuGet](https://img.shields.io/nuget/v/JIRA.GetAll.IssuesInPj.svg)](https://www.nuget.org/packages/JIRA.GetAll.IssuesInPj/)

This program get all issues from a project and store fields in a Excel file
 
https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/GetAllIssuesPj/Doc/Capture-Excel.PNG
 ![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/GetAllIssuesPj/Doc/Capture-Excel.PNG "Logo Title Text 1"))

# Arguments of the method

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllIssuesPj/GetAllIssuesPj.GIF
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllIssuesPj/GetAllIssuesPj.GIF "Logo Title Text 1"))

# How to use

1. Download the nuget package at : https://www.nuget.org/packages/RestAPI-JIRA-Lib/
2. USe Visual Studio or tool that use Nuget 
3. in your c# code use the method GetAllIssuesPj()
4. include the reference :   using JiraLib;

https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture4.PNG
![alt text]( https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture4.PNG "Logo Title Text 1")

5. use : await GetAllIs.GetAllIssuesPj(username, password, urlbase, projectname, Writeconsole);

method is packed and assembled in the dll : and included in the GetAllIS class

https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture5.PNG
![alt text]( https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture5.PNG "Logo Title Text 1")

https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture2.PNG
 ![alt text](https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture2.PNG  "Logo Title Text 1")

# Console output : 
What is displayed on your console screen if you choose  Writeconsole == 1 

https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture-console-output.PNG
![alt text]( https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture-console-output.PNG "Logo Title Text 1")
