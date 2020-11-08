using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Cw1
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            int licznik = 0;
            var httpClient= new HttpClient();
            var response = await httpClient.GetAsync("localhost");
            try
            {
                httpClient = new HttpClient();
                response = await httpClient.GetAsync("localhost");
            }
            catch (Exception error)
            {
                Console.Write("Bład w czasie pobierania strony.");
            }
            if (response == null)
            {
                throw new ArgumentNullException("Nie została podana żadna strona");
            }
            else
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MatchCollection matches = Regex.Matches(responseBody, @"\w+@\w+.\w+");
                    foreach (Match match in matches)
                    {
                        Console.WriteLine(match);
                        licznik++;
                    }
                    if (licznik == 0)
                    {
                        Console.WriteLine("Nie znaleziono adresów email.");
                    }
                    
                }
                else
                {
                    throw new ArgumentException();
                }
            }
                       
        }
    }
}
