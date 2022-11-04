namespace Awaiting
{
    public interface IServiceAccess
    {
        ValueTask<string> GetDataAsync();
    }
}