namespace WpfApp1.Models
{
    public interface IPrototype<T>
    {
        T Clone();
    }
}
