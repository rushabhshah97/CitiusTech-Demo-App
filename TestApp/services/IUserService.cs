using TestApp.Models;

namespace TestApp.services;

public interface IUserService
{
    public void SaveUserData(UserProfile userProfile);
    public void DeleteUserData();
    public UserProfile? GetUserData();
}