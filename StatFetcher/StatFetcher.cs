using GemBox.Spreadsheet;
using System.Xml.Linq;


namespace StatFetcher
{
    public class StatScraper
    {
        private const string url = "https://plk.pl/statystyki/xml/1";
        public void GetStats()
        {
            var filePath = "/var/www/html/bstattable";
            var path = $"{filePath}/index.html";
            var xml = XDocument.Load(url).Document?.ToString();
            if (xml is null)
            {
                throw new NullReferenceException("There was no file to download. Possible PLK website problem");
            }

            var result = xml.Substring(xml.IndexOf("<table"));
            result = result.Remove(result.LastIndexOf("</table>") + 8);

            File.WriteAllText(path, result);
        }
    }
}
