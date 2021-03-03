# GetAllUsersToXL() : method

1. Export to a Excel file, the list of all groups and of all the users belonging to each group : 
2. name of the export file : List-ALl-UsersGroups (Store all users's details in the file : List-ALl-UsersGroups.xlsx in the current directory)
3. Return an array of List objects which contains all JIRA users details from all JIRA groups

![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/Methods/GetAllUsersDetailToXL/Doc/List-ALl-UsersGroups.PNG "Logo Title Text 1"))

# Arguments of the method 

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllUsersToXL/GetAllUsersToXL-def.GIF  "Logo Title Text 1")

# How to use

1. Download the nuget package at : https://www.nuget.org/packages/RestAPI-JIRA-Lib/
2. USe Visual Studio or tool that use Nuget 
3. in your c# code use the method GetAllUsersToXL()
4. include the reference :   using JiraLib;

https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture4.PNG
![alt text]( https://github.com/guihen01/GetAllIssuesPj/blob/main/Doc/Capture4.PNG "Logo Title Text 1")

5. use : await Get1.GetAllUsersToXL(username, password, urlbase, projectname, Writeconsole);

method is packed and assembled in the dll  and included in the Get1 class

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Doc/GetAllUsersToXL/GetAllUsersToXL-inLib.GIF  "Logo Title Text 1")

