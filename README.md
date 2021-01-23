## RestApi-JIRA-Lib

1. Library of jira routines based on REST API
2. form : DLL
3. used to extract or to get informations on Jira server
4. is used with C# code 

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Library%20view%20v1.2.0.PNG

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/Library%20view%20v1.2.0.PNG "Logo Title Text 1")

# Publication

Package distributed as a nuget package at : https://www.nuget.org/packages/RestAPI-JIRA-Lib/

Is distributed as a .DLL library file

# Dependency 

1. package JiraLib : JiraLib.DLL
2. package Newtonsoft.Json;   

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
1. GetAllGroups
2. GetUSersFromGroup
3. Post1
4. ConverJsontoString
5. PickItems()   : create 2 files  : List-items.json & List-items.txt  which include the groups and/or names and/or emailadresses with string matching
6. Find-Users() : Returns a list of users that match the search string.(store the results in 2 files : List-users.json & List-users.txt)
7. JsontJObjectToString() : read a json formated file (type JObject) and convert to a text (string) formated file 
8. JsontJTokenToString() : read a json formated file (type JToken) and convert to a text (string) formated file 
9. JsontArrayToString() : read a json from a file (type JArray) and convert to a text (string) formated file 
10. GetServerInfo() : Get informations on Jira server
11. GetAllProjects() : Get all projects

# Pickitem() : routine

a simple routine which retruns a list of groups and/or names and/or emailadresses with string matching
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/PickItems/Result-Screenshots/Capture1.PNG "Logo Title Text 1") "Logo Title Text 1")

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/PickItems/Result-Screenshots/Capture2.PNG
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/PickItems/Result-Screenshots/Capture2.PNG "Logo Title Text 1")  

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/PickItems/Result-Screenshots/Capture3.PNG
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/PickItems/Result-Screenshots/Capture3.PNG "Logo Title Text 1") 
