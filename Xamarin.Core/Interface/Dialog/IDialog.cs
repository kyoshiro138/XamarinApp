namespace Xamarin.Core
{
    public interface IDialog
    {
        string Tag { get; set; }

        void Dismiss();

        void Show();
    }
}

