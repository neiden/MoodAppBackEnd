namespace Models;

public class Users
{
    public int User_Id { get; set; }
    public string? F_Name { get; set; }
    public string? L_Name { get; set; }
    public string? Phone_Number { get; set; }
    public string? Zipcode { get; set; }
    public DateTime Birthdate { get; set; }


    public Users()
    {

    }

    public Users(int User_Id, string F_Name, string L_Name, string Phone_Number, string Zipcode, DateTime Birthdate)
    {
        this.User_Id = User_Id;
        this.F_Name = F_Name;
        this.L_Name = L_Name;
        this.Phone_Number = Phone_Number;
        this.Zipcode = Zipcode;
        this.Birthdate = Birthdate;
    }
}
