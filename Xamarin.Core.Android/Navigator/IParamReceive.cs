using Android.OS;

namespace Xamarin.Core.Android
{
    public interface IParamReceive
    {
        object ReceiveParamObject(Bundle param, string tag);
    }
}

