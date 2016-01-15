namespace Xamarin.Core
{
    public interface INavigator
    {
        void NavigateTo(IScreen screen, bool isFirstLevelScreen = false);

        void NavigateBack();
    }
}

