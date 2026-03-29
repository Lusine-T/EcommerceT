namespace EcommerceTests.Core;
public static class Config
{
    public static string BaseUrl => "https://practice.qabrains.com/ecommerce";

    public static List<string> Browsers => new List<string>()
    {
        "chrome",
        "edge"
    };
}