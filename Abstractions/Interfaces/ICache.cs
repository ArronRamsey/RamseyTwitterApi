namespace FrameworkAbstractions.Interfaces
{
    public interface ICache
    {
        void Set(string key, object value);
        void Set(string key, object value, int lengthInMinutes);
        object Get(string key);
        T Get<T>(string key);
    }
}
