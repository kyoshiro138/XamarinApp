namespace Xamarin.Core
{
    public interface INavigator
    {
        void NavigateTo(IScreen screen);

        void NavigateBack();
    }
}

