using Database;

namespace Business.Services
{
    public interface IDataService
    {
        WaitlessContext GetContext();
    }
}