# GetUSersDetailsFromGroup()

1. The routine query and get all the details for users belonging to a specific JIRA group
1. The routine : GetUsersDetailFromGroup returns a list of objects (objects of type Group) List<GroupInfo>
2. & write result to file (Json style) : List-Details-from-group-{0}.txt" in the current directory
3. & write result to file (text file)  : List-accounts-from-group-{0}.txt" in the current directory
4. Details are : username, full name, email, group , active user or not
   
  public static async Task<List<GroupInfo>> GetUSersDetailFromGroup(string username, string password, string urlbase, string group)
  
   ![alt text](https://github.com/guihen01/Get.JIRA-USersDetailsFromGroup/blob/main/Capture1.PNG "Logo Title Text 1")
  
# Publication

1. Package distributed as a nuget package at : https://www.nuget.org/packages/Get.JIRA-USersDetailsFromGroup/

# Dependency

1. NETCoreApp 3.1
2. Newtonsoft.Json (>= 12.0.3)
3. the routine has been build with NETCoreApp 3. 1 , but can also be rebuild as needed with NetCoreApp.4 o 5 

# Inplementation

1. This method is part of a Library of jira routines (Jira methods) : JiraLib.dll based on REST API, but can be used without LibJira.dll
2. Included in JiraLib.dll and code source is in this repository
3. routine can be used and referenced with the JiraLib.dll reference in your c# project . Download the nuget package : https://www.nuget.org/packages/RestAPI-JIRA-Lib/
and make  call to this method in your code.
4. is used with C# code 
5.  Developed and tested in Visual Studio 2019.
6. can be used as so , whitout reference to library JiraLib.dll, but it is then needed, to insert the method GetUSersDetailsFromGroup()
code of routine in your project and rebuild the project.  
.
# Run 
exemple d'execution (sample running) : 

![alt text](https://github.com/guihen01/Get.JIRA-USersDetailsFromGroup/blob/main/Capture-2.PNG "Logo Title Text 1")

![alt text](https://github.com/guihen01/Get.JIRA-USersDetailsFromGroup/blob/main/Capture3.PNG "Logo Title Text 1")
