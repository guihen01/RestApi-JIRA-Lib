public class Rootobject
{
    public string name { get; set; }
    public string id { get; set; }
    public string title { get; set; }
    public string type { get; set; }
    public Properties properties { get; set; }
    public bool additionalProperties { get; set; }
}

public class Properties
{
    public Name name { get; set; }
}

public class Name
{
    public string type { get; set; }
}
