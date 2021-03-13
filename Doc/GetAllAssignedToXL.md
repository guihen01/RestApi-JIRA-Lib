# Method GetAllAssignedToXL
 [![JIRA.GetAll.IssuesInPj on fuget.org](https://www.fuget.org/packages/JIRA.GetAll.IssuesInPj/badge.svg)](https://www.fuget.org/packages/JIRA.GetAll.IssuesInPj)
[![Build status](https://ci.appveyor.com/api/projects/status/t25pekb23qqorbym?svg=true)](https://ci.appveyor.com/project/guihen01/getallissuespj)
[![NuGet](https://img.shields.io/nuget/v/JIRA.GetAll.IssuesInPj.svg)](https://www.nuget.org/packages/JIRA.GetAll.IssuesInPj/)

* It returns a list of all issues assigned to a user. Wrtites results to Excel
* Example : The grabscreen below, shows all issues assigned to username : guihen01

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllAssignedToXL/GetAllAssignedToXL-example1.GIF  "Logo Title Text 1"))

# Arguments of the method

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllAssignedToXL/GetAllAssignedToXL.GIF
![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllAssignedToXL/GetAllAssignedToXL.GIF  "Logo Title Text 1"))

# How to use

1. Download the nuget package at : https://www.nuget.org/packages/RestAPI-JIRA-Lib/
2. USe Visual Studio or tool that use Nuget 
3. in your c# code use the method GetAllAssignedToXL()
4. include the reference :   using JiraLib;

https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture4.PNG
![alt text]( https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture4.PNG "Logo Title Text 1")

5. use : await Get.GetAllAssignedToXL(username, password, urlbase, user, Writeconsole);

method is packed and assembled in the dll : and included in the Get class

![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllAssignedToXL/GetAllAssignedToXL-objectview.GIF "Logo Title Text 1")

# Examples  :
* Example : The grabscreen below, shows all issues assigned to username : gilunix
* The parameter Writeconsole is set to false ( Writeconsole = false) in : ( await Get.GetAllAssignedToXL(username, password, urlbase, user, Writeconsole);)

![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllAssignedToXL/run-3.GIF "Logo Title Text 1")

* Example : The grabscreen below, shows all issues assigned to username : guihen01
* The parameter Writeconsole is set to true ( Writeconsole = true) so more details are displayed 

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllAssignedToXL/run-1.GIF  "Logo Title Text 1")

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllAssignedToXL/run-2.GIF  "Logo Title Text 1")



