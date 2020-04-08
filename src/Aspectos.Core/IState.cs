namespace Aspectos
{
    public interface IState
    {
        string Key { get; }

        object GetValue();
    }
}