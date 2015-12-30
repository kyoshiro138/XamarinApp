using System;

namespace Xamarin.Core
{
    public class ServiceResponseEventArgs<T> : EventArgs where T : BaseResponseObject
    {
        public string RequestTag { get; private set; }

        public string ResponseString { get; private set; }

        public T ResponseObject { get; private set; }

        public ServiceResponseEventArgs(string tag, string responseStr)
            : this(tag, responseStr, null)
        {
        }

        public ServiceResponseEventArgs(string tag, string responseStr, T responseObj)
        {
            RequestTag = tag;
            ResponseString = responseStr;
            ResponseObject = responseObj;
        }
    }
}

