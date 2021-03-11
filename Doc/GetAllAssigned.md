# GetAllAssigned
 [![JIRA.GetAll.IssuesInPj on fuget.org](https://www.fuget.org/packages/JIRA.GetAll.IssuesInPj/badge.svg)](https://www.fuget.org/packages/JIRA.GetAll.IssuesInPj)
[![Build status](https://ci.appveyor.com/api/projects/status/t25pekb23qqorbym?svg=true)](https://ci.appveyor.com/project/guihen01/getallissuespj)
[![NuGet](https://img.shields.io/nuget/v/JIRA.GetAll.IssuesInPj.svg)](https://www.nuget.org/packages/JIRA.GetAll.IssuesInPj/)

. It returns a list of all issues assigned to a user. Wrtites results to 2 files : a json file and a text file : List-issues-{user}.json  and List-issues-{user}.txt

# Arguments of the method

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllAssigned/GetAllAssigned.GIF
![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllAssigned/GetAllAssigned.GIF  "Logo Title Text 1"))

# How to use

1. Download the nuget package at : https://www.nuget.org/packages/RestAPI-JIRA-Lib/
2. USe Visual Studio or tool that use Nuget 
3. in your c# code use the method GetAllAssigned()
4. include the reference :   using JiraLib;

https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture4.PNG
![alt text]( https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture4.PNG "Logo Title Text 1")

5. use : await Get.GetAllAssigned(username, password, urlbase, user, Writeconsole);

method is packed and assembled in the dll : and included in the Get class

![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllAssigned/GetAllAssigned-object.GIF "Logo Title Text 1")

# Example :
* in this example 12 issues where found, assigned to username : guihen01
* in this grab screen just one issue is displayed : issue key : PROD-23 , projetc key : PROD

 ![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllAssigned/Capture.GIF "Logo Title Text 1")
![alt text](  "Logo Title Text 1"))
