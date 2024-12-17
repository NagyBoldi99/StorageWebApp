public class User
{
    public int Id { get; set; } // Elsődleges kulcs
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // Validálási metódus
    public bool IsValid()
    {
        return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
    }
}
