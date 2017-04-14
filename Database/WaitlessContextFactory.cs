using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Database
{
    public class WaitlessContextFactory : IDbContextFactory<WaitlessContext>
    {
        public WaitlessContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<WaitlessContext>();
            builder.UseNpgsql("User ID=waitless;Password=waitless;Host=localhost;Port=5432;Database=waitless;Pooling=true;");
            return new WaitlessContext(builder.Options);
        }
    }
}
