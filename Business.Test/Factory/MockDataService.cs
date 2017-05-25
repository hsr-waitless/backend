using Business.Services;
using Database;

namespace Business.Test.Factory
{
    public class MockDataService : IDataService
    {
        private readonly WaitlessContext context;

        public MockDataService(WaitlessContext context)
        {
            this.context = context;
        }

        public WaitlessContext GetContext()
        {
            return context;
        }
    }
}