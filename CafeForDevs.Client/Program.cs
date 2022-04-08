using System;
using System.Net.Http;

namespace CafeForDevs.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var baseCafeUri = new Uri("http://lockalhost:37820");
            var cafeHttpClient = new CafeHttpClient(httpClient, baseCafeUri);
            
            var application = new Client(cafeHttpClient);
            application.Start();
        }
    }
}
