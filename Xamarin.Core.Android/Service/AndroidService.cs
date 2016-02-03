using System;
using System.Net.Http;
using System.Threading.Tasks;
using Android.App;
using Newtonsoft.Json;
using Android.Content;

namespace Xamarin.Core.Android
{
    public class AndroidService<T> : IService<T> where T : BaseResponseObject
    {
        public const string ErrorNoConnection = "ErrorNoConnection";

        private readonly NetworkUtil NetworkUtil;

        public HttpClient Client { get; protected set; }

        public event EventHandler<ServiceResponseEventArgs<T>> OnResponseSuccess;
        public event EventHandler<ServiceResponseEventArgs<T>> OnResponseFailed;
        public event EventHandler<ServiceResponseEventArgs<T>> OnParseError;

        public ProgressDialog Dialog { get; set; }

        public AndroidService(Context context, HttpClient client)
        {
            Client = client;
            NetworkUtil = new NetworkUtil(context);
        }

        public virtual async Task ExecuteGet(string tag, string url)
        {
            Console.WriteLine("[REQUEST {0}] [URL {1}]", tag, url);
            bool isServiceConnected = CheckServiceConnected(tag);
            if (isServiceConnected)
            {
                ShowProgressDialog();

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
                    HandleResponseFailure(tag, string.Empty);
                }
                CloseProgressDialog();
            }
        }

        public virtual async Task ExecuteGet<T1>(string tag, string url) where T1 : T
        {
            Console.WriteLine("[REQUEST {0}] [URL {1}]", tag, url);
            bool isServiceConnected = CheckServiceConnected(tag);
            if (isServiceConnected)
            {
                ShowProgressDialog();

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
                    HandleResponseFailure(tag, string.Empty);
                }
                CloseProgressDialog();
            }
        }

        protected void HandleResponseFailure(string tag, string errorMessage)
        {
            if (OnResponseFailed != null)
            {
                var args = new ServiceResponseEventArgs<T>(tag, errorMessage);
                OnResponseFailed.Invoke(this, args);
            }
        }

        protected bool CheckServiceConnected(string tag)
        {
            bool isNetworkConnected = NetworkUtil.IsWifiConnected() || NetworkUtil.IsMobileNetworkConnected();
            if (isNetworkConnected)
            {
                return true;
            }
            else
            {
                Console.WriteLine("[REQUEST {0}] [RESPONSE ERRROR {1}]", tag, ErrorNoConnection);
                HandleResponseFailure(tag, ErrorNoConnection);
                return false;
            }
        }

        protected void ShowProgressDialog()
        {
            if (Dialog != null && !Dialog.IsShowing)
            {
                Dialog.Show();
            }
        }

        protected void CloseProgressDialog()
        {
            if (Dialog != null && Dialog.IsShowing)
            {
                Dialog.Dismiss();
            }
        }
    }
}

