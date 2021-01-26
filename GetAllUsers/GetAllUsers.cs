
//-----------------------------------------------------------------------------------------
        //The routine : GetAllUsers returns a list of objects (objects of type Group) List<Group>
        //---------------------------------------------------------------------------------------
        /// <summary>
        ///  Get All Jira user's username (from all groups) . It returns the list of all users & groups.
        /// </summary>
        /// <returns> List<Group> : returns a list of objects (objects of type Group) : List<Group> </returns> 
        public static async Task<List<Group>> GetAllUsers(string username, string password, string urlbase)
        {
            //liste d'objets de type class Group qui  regroupe tous les groupes et  pour chaque groupe tous les usernames                        
            List<Group> Gr = new List<Group>();

            // The below routine will store All Jira groups in 2 files :List-groups.txt & List-groups.json in the current exec directory
            await Get.GetAllGroups("guihen01", "admin", "http://localhost:8080");

            //extraction of the groups list from file : List-groups.json
            string dir = Directory.GetCurrentDirectory();
            string path = dir + "/List-groups.json";
            if (File.Exists(path) != true)
            {
                Console.WriteLine("file doesnT exist");
            }
            //lecture dans un fichier des données au format Json
            string JsonResult;
            using (var tr = new StreamReader(path, true))
            {
                JsonResult = tr.ReadLine();
                tr.Close();
            }

            //Quey json (ref : https://www.newtonsoft.com/json/help/html/QueryJson.htm )
            JObject rss = JObject.Parse(JsonResult);

            //Query json whith LINQ  https://www.newtonsoft.com/json/help/html/QueryingLINQtoJSON.htm
            var postTitles =
               from p in rss["groups"]
               select (string)p["name"];

            int j = 0;
            string[] Users;
            foreach (var item in postTitles)
            {
                Console.WriteLine("group : {0} ", item);
                Group g1 = new Group();
                g1.groupname = item;

                //list of all users username in each group 
                //https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-return-a-value-from-a-task
                Users = await Task.Run(() => Get.GetUSernameFromGroup("guihen01", "admin", "http://localhost:8080", item));
                g1.Users = Users;

                Gr.Add(g1);  // ajout d<un objet de type groupe a la liste (add an object of type Group in the List)

            }

            return Gr;
        }