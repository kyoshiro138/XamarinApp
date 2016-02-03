namespace Xamarin.Core
{
    public interface IGridView : IControl
    {
        void SetDataSource<T>(IGridDataSource<T> dataSource) where T : class;
    }
}

