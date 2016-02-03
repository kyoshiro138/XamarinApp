using System;
using Xamarin.Core;
using System.Threading.Tasks;

namespace App.Shared
{
    public class UserManager
    {
        private IAppService Service { get; set; }

        private IDatabase Database { get; set; }

        private IAppStorage AppStorage { get; set; }

        public UserManager(IAppService service, IDatabase database, IAppStorage appStorage)
        {
            Service = service;
            Database = database;
            AppStorage = appStorage;
        }

        public async Task RequestUserBasicInfo(string username)
        {
            if (Service != null)
            {
                string url = string.Format("{0}?username={1}", ServiceConstants.UrlGetLoginInfo, username);
                await Service.ExecuteGet<GetLoginInfoResponse>(LoginScreenConst.ServiceGetBasicInfo, url);
            }
        }

        public async Task RequestAuthentication(User user, string password)
        {
            if (Service != null)
            {
                string url = string.Format("{0}?username={1}&password={2}", ServiceConstants.UrlAuthentication, user.Username, password);
                await Service.ExecuteGet<AuthenticationResponse>(LoginScreenConst.ServiceAuthenticate, url);
            }
        }

        public async Task RequestProfile(int userId)
        {
            if (AppStorage != null && Service != null)
            {
                string key = AppStorage.LoadString(AppStorageKeys.AuthenticationKey);
                string url = string.Format("{0}?key={1}&user_id={2}", ServiceConstants.UrlGetProfile, key, userId);
                await Service.ExecuteGet<AuthenticationResponse>(LoginScreenConst.ServiceGetProfile, url);
            }
        }

        public async Task<User> GetCurrentUser()
        {
            if (Database != null)
            {
                return await Database.GetFirst<User>();
            }
            return null;
        }

        public async Task SaveUserAuthentication(User user, string key)
        {
            if (AppStorage != null && Database != null)
            {
                AppStorage.Save(AppStorageKeys.AuthenticationKey, key);
                await Database.DeleteAll<User>();
                await Database.Insert<User>(user);
            }
        }

        public async Task RemoveUserAuthentication()
        {
            if (AppStorage != null && Database != null)
            {
                AppStorage.Remove(AppStorageKeys.AuthenticationKey);
                await Database.DeleteAll<User>();
            }
        }
    }
}

