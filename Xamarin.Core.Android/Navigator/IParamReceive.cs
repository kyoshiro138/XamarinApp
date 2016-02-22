using Android.OS;

namespace Xamarin.Core.Android
{
    public interface IParamReceive<TParam>
    {
        TParam ReceiveParamObject(Bundle param, string tag);
    }
}

