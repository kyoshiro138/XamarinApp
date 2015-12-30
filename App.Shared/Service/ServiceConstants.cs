using System;

namespace App.Shared
{
    public static class ServiceConstants
    {
        public const int ServiceTimeout = 30 * 1000; // 30 seconds

        public const string UrlGetLoginInfo = "http://demo1616447.mockable.io/getLoginInfo";
        public const string UrlAuthentication = "http://demo1616447.mockable.io/authenticate";
        public const string UrlGetProfile = "http://demo1616447.mockable.io/getProfile";
        public const string UrlGetTravelData = "http://demo1616447.mockable.io/getTravelData";

        public const int ErrorCodeUserNotExisted = 1001;
    }
}

