namespace Xamarin.Core
{
    public interface INavigator
    {
        void NavigateTo(IScreen screen, bool isFirstLevelScreen = false);

        void NavigateTo<TParam>(IScreen screen, TParam param, string paramTag, bool isFirstLevelScreen = false);

        void NavigateBack();
    }
}

