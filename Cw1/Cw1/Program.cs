using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Cw1
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var httpClient= new HttpClient();
            var response = await httpClient.GetAsync(args[0]);
            string responseBody = await response.Content.ReadAsStringAsync();
            MatchCollection matches = Regex.Matches(responseBody, @"\w+@\w+.\w+");
            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
