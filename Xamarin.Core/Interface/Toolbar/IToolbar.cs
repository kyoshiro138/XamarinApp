namespace Xamarin.Core
{
    public interface IToolbar
    {
        string Title { get; set; }

        void Show();

        void Hide();
    }
}

