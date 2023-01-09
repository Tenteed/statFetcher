using StatFetcher;

class Program
{

    static void Main(string[] args)
    {
        var statScraper = new StatScraper();
        statScraper.GetStats();
    }
}