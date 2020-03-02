using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    public class Program
    {
        //slowo kluczowe async, typ zwracany task, moze byc generyczny
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("hello world!");
            //int? tmp1 = null;
            //double tmp2 = 2.0;
            string tmp3 = "AAAAA";
            string tmp4 = "i psa";
            int w = 2;
            int q = 3;
            string path = $@"C:\Users\jd\Desktop\cw1";
            Console.WriteLine($"{tmp3} {tmp4} {w+q}");
            //bool tmp4 = true;

            //var tmp5 = 1;
            //var tmp6 = "ala makoto";
            ////var tmp7 = null;

            //var newperson = new Person { FirstName = "krzysztof" };

            var url = args.Length > 0 ? args[0] : "http://www.pja.edu.pl";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url); //metoda asynchorniczna, odpalana w nowym watku - niefajnie

            //np. bedzie status 200 OK, no typowe HTTP
            if(response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+",RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }
        }
    }
}
