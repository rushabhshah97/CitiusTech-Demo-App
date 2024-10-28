namespace TestApp.Models;

public class UserProfile(string nickName, string email, string phoneNumber = "")
{
    public string NickName { get; set; } = nickName;
    public string Email { get; set; } = email;
    public string PhoneNumber { get; set; } = phoneNumber;
}