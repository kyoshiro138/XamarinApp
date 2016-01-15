using System;

namespace App.Shared
{
    public static class ServiceConstants
    {
        public const int ServiceTimeout = 30 * 1000; // 30 seconds

        public const string UrlGetLoginInfo = "http://smartboox.getsandbox.com/user/getLoginInfo";
        public const string UrlAuthentication = "http://smartboox.getsandbox.com/user/authenticate";
        public const string UrlGetProfile = "http://smartboox.getsandbox.com/user/getProfile";
        public const string UrlGetTravelData = "http://smartboox.getsandbox.com/travel/getTravelData";

        public const int ErrorCodeUserNotExisted = 1001;
        public const int ErrorCodePasswordIncorrect = 1004;
    }
}

