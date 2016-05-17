using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hudl.Mjolnir.Command;
using ThorsHammerPoCConsole.Models;
using Hudl.Config;

namespace ThorsHammerPoCConsole
{
    public class Mjolnir : Command<UserDto>
    {

        public Mjolnir() 
            : base("core-client","core-user", TimeSpan.FromMilliseconds(15000))
        {
        }

        protected override async Task<UserDto> ExecuteAsync(CancellationToken token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51442/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/Mjolnir");
                    response.EnsureSuccessStatusCode();    // Throw if not a success code.

                    UserDto result = await response.Content.ReadAsAsync<UserDto>();
                    return result;
                }
                catch (HttpRequestException e)
                {
                    // Handle exception.
                }
            }
            return null;
        }
    }
}
