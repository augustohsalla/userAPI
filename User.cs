public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string UserEmail { get; set; }
    public string UserWebSite { get; set; }
}

public class UpdateUserModel
{
    public string FirstName { get; set; }
    public string UserWebSite { get; set; }
    public string UserEmail { get; set; }
}