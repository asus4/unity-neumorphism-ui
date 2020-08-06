
namespace Unity.UI.Ex
{
    public interface IListItem<T>
    {
        event System.Action<T> OnClick;
    }
}
