using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThorsHammerPoCConsole.Models;

namespace ThorsHammerPoCConsole
{
    class UserServices : IUserServices
    {
        public async Task<UserDto> GetInfo( int count, CancellationToken? token = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51442/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var request = string.Format("api/Mjolnir?count={0}", count);
                    HttpResponseMessage response = await client.GetAsync(request);
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
