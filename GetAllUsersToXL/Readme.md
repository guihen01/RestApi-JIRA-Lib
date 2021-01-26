
# Routine (method) : GetAllUsersToXL()

1. Get All Jira user's username (from all groups)
2. Store the list in several files : ( one file of username list per each group) List--users-from-group-.json & List-all-users-from-group .txt
3. Write the result in an Excel file
4. Returns a list of objects (objects of type Group) List

 ![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/GetAllUsersToXL/Capture-1.PNG "Logo Title Text 1")

# Inplementation

1. This method is part of a Library of jira routines (Jira methods) based on REST API
2. Included in JiraLib.dll
3. used to extract or to get informations on Jira server, Jira users, Groups, and so on ......
4. is used with C# code

# How to use it

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/GetAllUsersToXL/Capture-3.PNG "Logo Title Text 1")

# Publication

1. Package distributed as a nuget package at : https://www.nuget.org/packages/RestAPI-JIRA-Lib/
2. Is distributed as a .DLL library file

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/GetAllUsersToXL/Capture-5.PNG "Logo Title Text 1")

# Dependency

1. nuget package RestAPI-JIRA-Lib : JiraLib.DLL
2. nuget package Newtonsoft.Json;
3. nuget package EPPlus

![alt text](https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/GetAllUsersToXL/Capture-4.PNG "Logo Title Text 1")

# What we get 


# Sample 

Here the Data struture (In Debuger mode) . The Data object is listed . Data contain all groups and users

https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/GetAllUsersToXL/Capture-6.PNG
![alt text]( https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/GetAllUsersToXL/Capture-6.PNG "Logo Title Text 1")

 
