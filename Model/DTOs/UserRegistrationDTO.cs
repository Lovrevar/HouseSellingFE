namespace Model.DTOs;

public class UserRegistrationDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public string email { get; set; }
    
    
    public UserRegistrationDTO(string Name,string Surname, string Password, string email)
    {
        this.Name = Name;
        this.Surname = Surname;
        this.Password = Password;
        this.email = email;
    }
}