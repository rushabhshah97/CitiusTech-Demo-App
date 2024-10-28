namespace TestApp.Models;

public class BookData
{
    public BookData(string bookName, string subTitle, string bookUrl)
    {
        BookName = bookName;
        SubTitle = subTitle;
        BookUrl = bookUrl;
    }

    public string BookName { get; set; }
    public string SubTitle { get; set; }
    public string BookUrl { get; set; }
}