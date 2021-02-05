using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JiraLib
{
    class Http
    {
        /// <summary>
        /// Send demand of authorization to server , to get or post request via Http Rest API
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="url"> url of the server</param>
        /// <returns> acceptance or reject of the authorization by server </returns>
        public static async Task<string> GetHttpResponse(string username, string password, string url)
        {
            var client = new HttpClient();
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);

            HttpResponseMessage response;
            response = new HttpResponseMessage();
            string result = " ";
            try
            {
                response = await client.GetAsync(url);
                Console.WriteLine(response.StatusCode);
                if (response == null)
                {
                    throw new ArgumentNullException();
                }
                if (response.StatusCode == HttpStatusCode.Unauthorized) //https://docs.microsoft.com/en-us/dotnet/api/system.net.httpstatuscode?view=net-5.0
                {
                    throw new Unauthorized();
                }

                result = await response.Content.ReadAsStringAsync();
                client.Dispose();
            }
            catch (Unauthorized e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("account not authorized to this sever or bad account ");

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Response is null");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("The requestUri must be an absolute URI or BaseAddress must be set.");
                Console.WriteLine(e.Message);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout");
                Console.WriteLine(e.Message);
            }
            catch (TaskCanceledException e)
            {
                Console.WriteLine(".NET Core and .NET 5.0 and later only: The request failed due to timeout.");
                Console.WriteLine(e.Message);
            }

            return result;
        }

    }

    [Serializable]
    internal class Unauthorized : Exception
    {
        public Unauthorized()
        {
        }

        public Unauthorized(string message) : base(message)
        {
        }

        public Unauthorized(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected Unauthorized(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
