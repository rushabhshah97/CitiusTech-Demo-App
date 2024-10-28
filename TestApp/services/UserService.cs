using Microsoft.Maui.Storage;
using Newtonsoft.Json;
using TestApp.Common;
using TestApp.Models;

namespace TestApp.services;

public class UserService : IUserService
{
    public void SaveUserData(UserProfile userProfile)
    {
        Preferences.Set(Constants.UserProfileKey, JsonConvert.SerializeObject(userProfile));
    }

    public void DeleteUserData()
    {
        Preferences.Clear();
    }

    public UserProfile? GetUserData()
    {
        var data = Preferences.Get(Constants.UserProfileKey, string.Empty);
        return string.IsNullOrEmpty(data) ? null : JsonConvert.DeserializeObject<UserProfile>(data)!;
    }
}