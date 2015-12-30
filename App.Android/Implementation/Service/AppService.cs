using App.Shared;
using Xamarin.Core.Android;
using System.Net.Http;
using ModernHttpClient;

namespace App.Android
{
    public class AppService : AndroidService<AppResponseObject>, IAppService
    {
        public AppService()
            : base(null)
        {
            Client = new HttpClient(new NativeMessageHandler());
//            Client.Timeout = new System.TimeSpan(ServiceConstants.ServiceTimeout);
            System.Console.WriteLine(Client.Timeout.Ticks);
        }

        public AppService(HttpClient client)
            : base(client)
        {
        }
    }
}

