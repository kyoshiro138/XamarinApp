namespace Xamarin.Core
{
    public interface IToolbar
    {
        string Title { get; set; }

        string NavigationIcon { set; }

        void Show();

        void Hide();
    }
}

