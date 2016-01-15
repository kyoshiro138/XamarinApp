using System;
using Xamarin.Core;
using System.Threading.Tasks;

namespace App.Shared
{
    public class UserManager
    {
        public IAppService Service { get; private set; }

        private IDatabase Database { get; set; }

        private IAppStorage AppStorage { get; set; }

        public UserManager(IAppService service, IDatabase database, IAppStorage appStorage)
        {
            Service = service;
            Database = database;
            AppStorage = appStorage;
        }

        public async Task StartGetBasicInfo(string username)
        {
            string url = string.Format("{0}?username={1}", ServiceConstants.UrlGetLoginInfo, username);
            await Service.ExecuteGet<GetLoginInfoResponse>(LoginScreenConst.ServiceGetBasicInfo, url);
        }

        public async Task Authenticate(User user, string password)
        {
            string url = string.Format("{0}?username={1}&password={2}", ServiceConstants.UrlAuthentication, user.Username, password);
            await Service.ExecuteGet<AuthenticationResponse>(LoginScreenConst.ServiceAuthenticate, url);
        }

        public async Task GetProfile(int userId)
        {
            string key = AppStorage.LoadString(AppStorageKeys.AuthenticationKey);
            string url = string.Format("{0}?key={1}&user_id={2}", ServiceConstants.UrlGetProfile, key, userId);
            await Service.ExecuteGet<AuthenticationResponse>(LoginScreenConst.ServiceGetProfile, url);
        }

        public async Task<User> GetCurrentUser()
        {
            return await Database.GetFirst<User>();
        }

        public async Task SaveUserAuthentication(User user, string key)
        {
            AppStorage.Save(AppStorageKeys.AuthenticationKey, key);
            await Database.DeleteAll<User>();
            await Database.Insert<User>(user);
        }
    }
}

