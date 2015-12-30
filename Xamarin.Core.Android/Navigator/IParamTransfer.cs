using Android.OS;

namespace Xamarin.Core.Android
{
    public interface IParamTransfer
    {
        Bundle CreateParamBundle(object param, string paramTag);
    }
}

