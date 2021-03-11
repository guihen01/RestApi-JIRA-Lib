## RestApi-JIRA-Lib

[![RestAPI-JIRA-Lib on fuget.org](https://www.fuget.org/packages/RestAPI-JIRA-Lib/badge.svg)](https://www.fuget.org/packages/RestAPI-JIRA-Lib)
[![Build status](https://ci.appveyor.com/api/projects/status/aulan7yl97p39r70?svg=true)](https://ci.appveyor.com/project/guihen01/restapi-jira-lib)
[![NuGet](https://img.shields.io/nuget/v/RestApi-JIRA-Lib.svg)](https://www.nuget.org/packages/RestApi-JIRA-Lib/) 

1. Library of jira routines based on REST API
2. form : DLL
3. used to extract or to get informations on Jira server and on Jira objects ( groups, users, issues , .....)
4. is used with C# code 

# Solution Explorer 

List of classes and modules packed in the library :  

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/RestApi-Jira-Lib-Solution%20.GIF
![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/RestApi-Jira-Lib-Solution%20.GIF "Logo Title Text 1")

# Publication

1. Package distributed as a nuget package at : https://www.nuget.org/packages/RestAPI-JIRA-Lib/
2. Package, also, distributed as a nuget package at : https://github.com/guihen01/RestApi-JIRA-Lib/packages/611771 

Is distributed as a .DLL library file

# Dependency 

1. package EPPlus
2. package Newtonsoft.Json; 

![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/Doc/Installed%20nuget%20packages-1.PNG "Logo Title Text 1")

1. Packages referenced in the Library : 

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/Doc/Dependency-1.PNG "Logo Title Text 1")

# Inplementation

1. Download the nuget package : https://www.nuget.org/packages/RestAPI-JIRA-Lib/ in your project

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/Rest-api-Lib%20package.GIF "Logo Title Text 1")

2. It is also available for download at https://github.com/guihen01/RestApi-JIRA-Lib/releases/

3. JiraLib methods can be used and referenced with the JiraLib.dll reference in your c# project 
4. is used with C# code
5. Developed and tested in Visual Studio 2019

# How to use

1. using JiraLib;            in your project, reference this package (package name : RestAPI-JIRA-Lib) 
2. using Newtonsoft.Json;    in your project,  reference this package 
3. using OfficeOpenXml;      only for JiraLib methods using Excel, such as GetAllUsersDetailToXL() or GetAllUsersToXL() 
4. using System.Threading.Tasks;   Routines are async methods and need the use of await  and async Task declaration instruction 

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/Get%20Users%20From%20Group/Screenshots/Capture%20How%20to%20use.PNG "Logo Title Text 1")

routines are async . so use await instruction for some routines 

# Routines inside the Library : 

1. GetAllGroups  : Get a list of all Jira groups and save the list in 2 files : List-groups.json & List-groups.txt
2. GetUSersFromGroup() : Get the list of all user's username belonging to a group and save the list in 2 files : List-users.json & List-users.txt . Print the list to the console
3. GetUsernameFromGroup(username, password, urlbase, group) :
Get the list of all user's username belonging to a group and save the list in 2 files : List-username-from-group-{0}.json & List-username-from-group-{0}.txt . return a list of group's username as a string array 
4. Post1
5. ConverJsontoString
6. PickItems()   : create 2 files  : List-items.json & List-items.txt  which include the groups and/or names and/or emailadresses with string matching
7. Find-Users() : Returns a list of users that match the search string.(store the results in 2 files : List-users.json & List-users.txt)
8. JsontJObjectToString() : read a json formated file (type JObject) and convert to a text (string) formated file 
9. JsontJTokenToString() : read a json formated file (type JToken) and convert to a text (string) formated file 
10. JsontArrayToString() : read a json from a file (type JArray) and convert to a text (string) formated file 
11. GetServerInfo() : Get informations on Jira server
12. GetAllProjects() : Get all Jira projects and save the list in 2 files : List-projects.json & List-projects.txt
13. GetAllUsers() :  Get All Jira user's username (from all groups)  and store the list for each group  in 2 files : List-all-users-from-group.json & List-all-users-from-group.txt ( store it in the current directory). Returns a list of objects (objects of type Group) List
14. GetAllUsersToXL() : Get the list of all Jira users and groups and store the list for each group in 2 files : List-username-from-group-...json & List-username-from-group-...txt & write result to an Excel file (List-ALl-UsersGroups.xlsx). Returns a list of objects (objects of type Group) List
15. GetUsersDetailFromGroup() :  returns a list of users details for a group. As objects (objects of type Group) List<GroupInfo> & write result to file (Json style) : List-Details-from-group-{0}.txt" & write result to file (text file)  : List-accounts-from-group-{0}.txt" Details are : username, full name, email, group , active user or not 
16. GetAllUsersDetail() : get all users details from all JIRA groups. GEt results as  json file and Text file and as an array of Objects list : 
 <List<GroupInfo>[]
17. GetHttpResponse() :  include try catch methods to get errors when using http protocol services for geting or posting Rest Api Demands to JIRA server.
18. GetAllUsersDetailToXL() : Execute a GET http request on a Jira server with Rest API, to get all users details from all JIRA groups 
. Store all users's details in a file : List-ALl-UsersGroups.xlsx in the current directory
. Return an array of List objects which contains all JIRA users details from all JIRA groups
19. GetAllIssuesPj() Get a list of all issues in a project. Write list to a Excel file with list of all issues status, assignee,resolution, ...... 
20. JiraPostRequest() This simple method allows to make a post rest api request to a jira server . write results to console & and to files located in the current directory .:  Response.txt  & Response.json. Parameters to give is a json file , containing your post request
21. GetProjectIssues() : Get all issues details in a project. Get it from the json JObject Ob parameter. It parses and anlizes the JObject object & returns an array of all Issues ( type of array : IssueInfos[]) inside the project.:  GetProjectIssues(string projectname, JObject Ob, int NumberOfIssues)
22. GetUnrIssuesPj() : returns a list of  all non resolved issues in a project. Write them in a Excel file 
23. GetAllAssigned() : It returns a list of all issues assigned to a user. Wrtites results to 2 files : a json file and a text file : List-issues-{user}.json and List-issues-{user}.txt
24. CreateGroup() : Create a Jira group
 
# detailed list of all methods in the library 

. Goto to the following github site page for the methods docs : https://guihen01.github.io/RestApi-JIRA-Lib/RestApi-JIRA-Lib.html  
    (Master site : https://guihen01.github.io/index.html ) 

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/web-site-doc.GIF  "Logo Title Text 1"))

# Pickitem() :method

a simple routine which retruns a list of groups and/or names and/or emailadresses with string matching
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/PickItems/Result-Screenshots/Capture1.PNG "Logo Title Text 1") "Logo Title Text 1")

https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/PickItems/Result-Screenshots/Capture2.PNG
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/PickItems/Result-Screenshots/Capture2.PNG "Logo Title Text 1")  

https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/PickItems/Result-Screenshots/Capture3.PNG
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/PickItems/Result-Screenshots/Capture3.PNG "Logo Title Text 1") 

# GetAllUsersToXL() : method

1. Export to a Excel file, the list of all groups and of all the users belonging to each group : 
2. name of the export file : List-ALl-UsersGroups (Store all users's details in the file : List-ALl-UsersGroups.xlsx in the current directory)
3. Return an array of List objects which contains all JIRA users details from all JIRA groups

![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/GetAllUsersDetailToXL/Doc/List-ALl-UsersGroups.PNG "Logo Title Text 1") "Logo Title Text 1")

 # GetAllIssuesPj() : method
 
https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/GetAllIssuesPj/Doc/Capture-Excel.PNG
 ![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/GetAllIssuesPj/Doc/Capture-Excel.PNG "Logo Title Text 1") "Logo Title Text 1")
 
# GetUnrIssuesPj() : method

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/Capture-GetUnrresokvedIssues.PNG
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/Capture-GetUnrresokvedIssues.PNG "Logo Title Text 1") "Logo Title Text 1")


