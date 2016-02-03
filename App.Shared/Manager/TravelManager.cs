using System;
using Xamarin.Core;
using System.Threading.Tasks;

namespace App.Shared
{
    public class TravelManager
    {
        private IAppService Service { get; set; }

        private IDatabase Database { get; set; }

        private IAppStorage AppStorage { get; set; }

        public TravelManager(IAppService service, IDatabase database, IAppStorage storage)
        {
            Service = service;
            Database = database;
            AppStorage = storage;
        }

        public async Task RequestTravelData(int userRole)
        {
            if (Service != null && AppStorage != null)
            {
                if (userRole == (int)User.RoleType.Guest)
                {
                    await Service.ExecuteGet<GetTravelDataResponse>(HomeScreenConst.ServiceGetTravelData, ServiceConstants.UrlGetTravelDataAsGuest);
                }
                else
                {
                    string key = AppStorage.LoadString(AppStorageKeys.AuthenticationKey);
                    string url = string.Format("{0}?key={1}", ServiceConstants.UrlGetTravelData, key);
                    await Service.ExecuteGet<AuthenticationResponse>(HomeScreenConst.ServiceGetTravelData, url);
                }
            }
        }
    }
}

