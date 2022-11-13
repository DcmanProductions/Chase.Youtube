using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace Chase.Youtube;

public static class YTUrlParser
{

    public static string GetDirectUrl(string key)
    {
        return "";
    }

    private static string GetHTML(string key)
    {
        string html = "";
        string url = $"https://youtube.com/watch?v={key}";
        using (HttpClient client = new())
        {
            using HttpResponseMessage response = client.GetAsync(url).Result;
            if (response != null && response.IsSuccessStatusCode)
            {
                html = response.Content.ReadAsStringAsync().Result;
            }
        }

        string json = Regex.Match(html, "(?<=(var ytInitialPlayerResponse = ))((?!\\};).)*.").Value;
        return json;
    }

}