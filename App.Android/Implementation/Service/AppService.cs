using App.Shared;
using Xamarin.Core.Android;
using System.Net.Http;
using ModernHttpClient;
using System.Threading.Tasks;
using Java.Net;
using Android.Content;

namespace App.Android
{
    public class AppService : AndroidService<AppResponseObject>, IAppService
    {
        public AppService(Context context)
            : base(context, null)
        {
            Client = new HttpClient(new NativeMessageHandler());
        }

        public AppService(Context context, HttpClient client)
            : base(context, client)
        {
        }

        public override async Task ExecuteGet(string tag, string url)
        {
            try
            {
                await base.ExecuteGet(tag, url);
            }
            catch (UnknownHostException e)
            {
                e.PrintStackTrace();
                HandleResponseFailure(tag, string.Empty);
                CloseProgressDialog();
            }
        }

        public override async Task ExecuteGet<T1>(string tag, string url)
        {
            try
            {
                await base.ExecuteGet<T1>(tag, url);
            }
            catch (UnknownHostException e)
            {
                e.PrintStackTrace();
                HandleResponseFailure(tag, string.Empty);
                CloseProgressDialog();
            }
        }
    }
}

