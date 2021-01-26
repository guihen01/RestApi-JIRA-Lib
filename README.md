## RestApi-JIRA-Lib

1. Library of jira routines based on REST API
2. form : DLL
3. used to extract or to get informations on Jira server
4. is used with C# code 

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/SolutionView1.PNGG

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/SolutionView1.PNG "Logo Title Text 1")

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/SolutionView2.PNG

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/SolutionView2.PNG "Logo Title Text 1")

# Publication

Package distributed as a nuget package at : https://www.nuget.org/packages/RestAPI-JIRA-Lib/

Is distributed as a .DLL library file

# Dependency 

1. package JiraLib : JiraLib.DLL
2. package Newtonsoft.Json;  

![alt text](  "Logo Title Text 1")

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/nuget%20packages%20needed.PNG
![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/nuget%20packages%20needed.PNG  "Logo Title Text 1")

# How to use

1. using JiraLib             in you project, reference this package   
2. using Newtonsoft.Json;  ;  in your project,  reference this package 

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Get%20Users%20From%20Group/Screenshots/Capture%20How%20to%20use.PNG "Logo Title Text 1")

See How to use it , in : https://github.com/guihen01/RestApi-JIRA-Lib/tree/main/Get-All-Jira-Groups

Also in : https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Get%20Users%20From%20Group/Screenshots/Capture%20How%20to%20use.PNG

routines are async . so use await instruction for some routines 

# Download
1. Download the nuget package at : https://www.nuget.org/packages/RestAPI-JIRA-Lib/

OR

2. Download the .DLL and others items at https://github.com/guihen01/RestApi-JIRA-Lib/releases/
 
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
15. CreateGroup() : Create a Jira group

# Pickitem() :method

a simple routine which retruns a list of groups and/or names and/or emailadresses with string matching
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/PickItems/Result-Screenshots/Capture1.PNG "Logo Title Text 1") "Logo Title Text 1")

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/PickItems/Result-Screenshots/Capture2.PNG
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/PickItems/Result-Screenshots/Capture2.PNG "Logo Title Text 1")  

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/PickItems/Result-Screenshots/Capture3.PNG
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/PickItems/Result-Screenshots/Capture3.PNG "Logo Title Text 1") 

# GetAllUsersToXL() : method

1. Export to a Excel file, the list of all groups and of all the users belonging to each group : 
2. name of the export file : List-ALl-UsersGroups

![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Excel%20file%20List-ALl-UsersGroups.PNG "Logo Title Text 1") "Logo Title Text 1")

