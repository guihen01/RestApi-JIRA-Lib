# GetAllUsersDetailToXL()


. Execute a GET http request on a Jira server with Rest API, to get all users details from all JIRA groups

. Store all users's details in a file : List-ALl-UsersGroups.xlsx in the current directory

. Return an array of List objects which contains all JIRA users details from all JIRA groups

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/GetAllUsersDetailToXL/Doc/Capture1.PNG "Logo Title Text 1")

# file List-ALl-UsersGroups.xlsx
![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/GetAllUsersDetailToXL/Doc/List-ALl-UsersGroups.PNG "Logo Title Text 1")

# Inplementation

This method is part of a Library of jira routines (Jira methods) : JiraLib.dll based on REST API, but can be used without LibJira.dll
Included in JiraLib.dll and code source is in this repository
routine can be used and referenced with the JiraLib.dll reference in your c# project . Download the nuget package : https://www.nuget.org/packages/RestAPI-JIRA-Lib/ and make call to this method in your code.
is used with C# code
Developed and tested in Visual Studio 2019.
can be used as so , whitout reference to library JiraLib.dll, but it is then needed, to insert the method GetUSersDetailsFromGroup() code of routine in your project and rebuild the project.
