using System;
using Database;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class DataService : IDataService
    {
        private readonly DbContextOptions<WaitlessContext> options;

        public DataService(DbContextOptions<WaitlessContext> options)
        {
            this.options = options;
        }

        public WaitlessContext GetContext()
        {
            return new WaitlessContext(options);
        }
    }
}