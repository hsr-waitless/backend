using Database;
using Microsoft.EntityFrameworkCore;
using System;

namespace Business.Test.Factory
{
    class MockContextFactory
    {

        public static WaitlessContext Create() {

            var builder = new DbContextOptionsBuilder<WaitlessContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new WaitlessContext(builder.Options);

            return context;

        }
    }
}
