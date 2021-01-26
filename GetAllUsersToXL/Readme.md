
# Routine (method) : GetAllUsers()
Get All Jira user's username (from all groups)
Store the list in several files : ( one file of username list per each group) List--users-from-group-.json & List-all-users-from-group .txt
Returns a list of objects (objects of type Group) List
alt text

# Inplementation
This method is part of a Library of jira routines (Jira methods) based on REST API
Included in JiraLib.dll
used to extract or to get informations on Jira server, Jira users, Groups, and so on ......
is used with C# code
How to use it
alt text

# Publication
Package distributed as a nuget package at : https://www.nuget.org/packages/RestAPI-JIRA-Lib/

Is distributed as a .DLL library file

# Dependency
package JiraLib : JiraLib.DLL
package Newtonsoft.Json;
https://github.com/guihen01/RestApi-JIRA-Lib/blob/main/nuget%20packages%20needed.PNG alt text

# How to use
using JiraLib in you project, reference this package
using Newtonsoft.Json; ; in your project, reference this package