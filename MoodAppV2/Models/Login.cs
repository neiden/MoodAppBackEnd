public class Login
{
    public string? Username { get; set; }
    public string? P_hash_salt { get; set; }
    public string? Pwd { get; set; }
    public int U_Id { get; set; }
    public string? Email { get; set; }

    public Login()
    {

    }

    public Login(string Username, string P_hash_salt, string Pwd, int U_Id, string Email)
    {
        this.Username = Username;
        this.P_hash_salt = P_hash_salt;
        this.Pwd = Pwd;
        this.U_Id = U_Id;
        this.Email = Email;
    }
}