using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Hudl.Config;
using Hudl.Mjolnir.Command;
using ThorsHammerPoCConsole.Models;


namespace ThorsHammerPoCConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigProvider.UseProvider(new FileConfigurationProvider(@"c:\Users\paul.nguyen\Documents\Mjolnir", "MjolnirConfiguration.txt"));
            CommandContext.Stats = new MyStats();
            //CancellationTokenSource source = new CancellationTokenSource();
            //CancellationToken token = source.Token;
            //var Hammer = new Mjolnir();
            //var result = Hammer.InvokeAsync();
            //Console.WriteLine(result.Result.Count);
            //Console.WriteLine(result.Result.Message);

            var services = new UserServices();
            int count = 0;
            while (count < 1000)
            {
                count++;
                var result2 = services.GetInfo(count, null);
                if (result2 != null && result2.Result != null && result2.Result.Count != null)
                {

                    Console.WriteLine(result2.Result.Count);
                }
                else
                {
                    Console.WriteLine("NULL");  
                }
            }
            //result.Invoke();

            //RunAsync().Wait();
        }

        //public static async Task RunAsync()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:51442/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        try
        //        {
        //            HttpResponseMessage response = await client.GetAsync("api/Mjolnir");
        //            response.EnsureSuccessStatusCode();    // Throw if not a success code.

        //            UserDto result = await response.Content.ReadAsAsync<UserDto>();
        //            Console.WriteLine(result.Count);
        //            Console.WriteLine("test");
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            // Handle exception.
        //        }
        //    }
        //}

    }
}
