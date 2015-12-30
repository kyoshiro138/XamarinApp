using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace Xamarin.Core.Android
{
    public class AndroidService<T> : IService<T> where T : BaseResponseObject
    {
        public HttpClient Client { get; protected set; }

        public event EventHandler<ServiceResponseEventArgs<T>> OnResponseSuccess;
        public event EventHandler<ServiceResponseEventArgs<T>> OnResponseFailed;
        public event EventHandler<ServiceResponseEventArgs<T>> OnParseError;

        public AndroidService(HttpClient client)
        {
            Client = client;
        }

        public async Task ExecuteGet(string tag, string url)
        {
            Console.WriteLine("[REQUEST {0}] [URL {1}]", tag, url);

            var responseMessage = await Client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                string responseString = await responseMessage.Content.ReadAsStringAsync();

                Console.WriteLine("[REQUEST {0}] [RESPONSE {1}]", tag, responseString);

                if (OnResponseSuccess != null)
                {
                    var args = new ServiceResponseEventArgs<T>(tag, responseString);
                    OnResponseSuccess.Invoke(this, args);
                }
            }
            else
            {
                Console.WriteLine("[REQUEST {0}] [RESPONSE ERRROR STATUS {1}]", tag, responseMessage.StatusCode);
                if (OnResponseFailed != null)
                {
                    var args = new ServiceResponseEventArgs<T>(tag, string.Empty);
                    OnResponseFailed.Invoke(this, args);
                }
            }
        }

        public async Task ExecuteGet<T1>(string tag, string url) where T1 : T
        {
            Console.WriteLine("[REQUEST {0}] [URL {1}]", tag, url);

            var responseMessage = await Client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                string responseString = await responseMessage.Content.ReadAsStringAsync();

                Console.WriteLine("[REQUEST {0}] [RESPONSE {1}]", tag, responseString);
                try
                {
                    T1 responseObject = JsonConvert.DeserializeObject<T1>(responseString);
                    if (OnResponseSuccess != null)
                    {
                        var args = new ServiceResponseEventArgs<T>(tag, responseString, responseObject);
                        OnResponseSuccess.Invoke(this, args);
                    }
                }
                catch (JsonException e)
                {
                    Console.WriteLine("[REQUEST {0}] [PARSE ERROR {1}]", tag, e.Message);
                    if (OnParseError != null)
                    {
                        var args = new ServiceResponseEventArgs<T>(tag, responseString);
                        OnParseError(this, args);
                    }
                }
            }
            else
            {
                Console.WriteLine("[REQUEST {0}] [RESPONSE ERRROR STATUS {1}]", tag, responseMessage.StatusCode);
                if (OnResponseFailed != null)
                {
                    var args = new ServiceResponseEventArgs<T>(tag, string.Empty);
                    OnResponseFailed.Invoke(this, args);
                }
            }
        }
    }
}

