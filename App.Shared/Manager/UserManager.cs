using System;
using Xamarin.Core;
using System.Threading.Tasks;

namespace App.Shared
{
    public class UserManager
    {
        public IAppService Service { get; private set; }

        public UserManager(IAppService service)
        {
            Service = service;
        }

        public async Task StartGetBasicInfo(string username)
        {
            if (!username.Equals(LoginScreenConst.TestUsername))
            {
                username = LoginScreenConst.GuestUsername;
            }

            string url = string.Format("{0}?username={1}", ServiceConstants.UrlGetLoginInfo, username);
            await Service.ExecuteGet<GetLoginInfoResponse>(LoginScreenConst.ServiceGetBasicInfo, url);
        }
    }
}

