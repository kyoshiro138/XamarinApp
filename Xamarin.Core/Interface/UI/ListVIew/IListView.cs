namespace Xamarin.Core
{
    public interface IListView : IControl
    {
        void SetDataSource<T>(IListDataSource<T> dataSource) where T : class;
    }
}

