using System;
using Xamarin.Core;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public async Task RequestTravelData(string tag, int userRole)
        {
            if (Service != null && AppStorage != null)
            {
                if (userRole == (int)User.RoleType.Guest)
                {
                    await Service.ExecuteGet<GetTravelDataResponse>(tag, ServiceConstants.UrlGetTravelDataAsGuest);
                }
                else
                {
                    string key = AppStorage.LoadString(AppStorageKeys.AuthenticationKey);
                    string url = string.Format("{0}?key={1}", ServiceConstants.UrlGetTravelData, key);
                    await Service.ExecuteGet<GetTravelDataResponse>(tag, url);
                }
            }
        }

        public async Task SaveTravelData(List<TravelPlace> data)
        {
            if (Database != null)
            {
                try
                {
                    await Database.DeleteAll<TravelPlace>();
                    await Database.DeleteAll<PlaceLocation>();
                    foreach (TravelPlace place in data)
                    {
                        if (place.Locations != null && place.Locations.Count > 0)
                        {
                            await Database.InsertAll<PlaceLocation>(place.Locations);
                            place.Locations.Clear();
                        }
                    }

                    await Database.InsertAll<TravelPlace>(data);
                }
                catch (Exception e)
                {
                    string t1 = e.StackTrace;
                }
            }
        }

        public async Task<List<TravelPlace>> GetLocalPlaceList()
        {
            if (Database != null)
            {
                return await Database.GetAll<TravelPlace>();
            }
            return new List<TravelPlace>();
        }

        public async Task<List<PlaceLocation>> GetLocalLocationList(int placeId)
        {
            if (Database != null)
            {
                List<PlaceLocation> locations = await Database.GetAll<PlaceLocation>();
                return locations.FindAll(l => l.PlaceId == placeId);
            }
            return new List<PlaceLocation>();
        }
    }
}

