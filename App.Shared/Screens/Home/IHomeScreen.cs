using Xamarin.Core;

namespace App.Shared
{
    public interface IHomeScreen : IScreen
    {
        UserManager UserManager { get; }

        TravelManager TravelManager { get; }
    }
}

