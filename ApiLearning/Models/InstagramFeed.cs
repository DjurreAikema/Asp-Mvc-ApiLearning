using System.Collections.Generic;

public class User
{
    public string full_name { get; set; }
    public string profile_picture { get; set; }
}

public class StandardResolution
{
    public string url { get; set; }
}

public class Images
{
    public StandardResolution standard_resolution { get; set; }
}

public class Caption
{
    public string text { get; set; }
}

public class Likes
{
    public int count { get; set; }
}

public class Comments
{
    public int count { get; set; }
}

public class Datum
{
    public string id { get; set; }
    public User user { get; set; }
    public Images images { get; set; }
    public Caption caption { get; set; }
    public Likes likes { get; set; }
    public Comments comments { get; set; }
    public string link { get; set; }
}

public class InstagramFeed
{
    public List<Datum> data { get; set; }
}