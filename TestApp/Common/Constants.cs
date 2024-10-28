using System.Collections.Generic;
using TestApp.Models;

namespace TestApp.Common;

public static class Constants
{
    public static string EmailRegex = "^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$";

    public static string UserProfileKey = "userProfile";

    public static List<BookData> Books { get; set; } = new ()
    {
        new BookData("Google", "Part - 1", "https://www.google.com"),
        new BookData("FB", "Part - 2", "https://www.fb.com"),
        new BookData("Instagram", "Part - 3", "https://www.instagram.com"),
    };
}