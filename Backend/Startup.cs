using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Database;
using Business.Services;

namespace Backend
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddMvc();

      var sqlConnectionString = Configuration.GetConnectionString("PostgreSqlProvider");

      services.AddDbContext<WaitlessContext>(options =>
          options.UseNpgsql(sqlConnectionString)
      );

      services.AddSignalR(options =>
      {
        options.Hubs.EnableDetailedErrors = true;
      });

	  services.AddTransient<MenuService>();
	  services.AddTransient<SubmenuService>();
	  services.AddTransient<ItemTypeService>();
      services.AddTransient<TableService>();
      services.AddTransient<AssignOrderService>();
      services.AddTransient<TabletService>();
      services.AddTransient<OrderService>();

      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy",
          builder => builder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials());
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      app.UseCors("CorsPolicy");

      app.UseMvc();

      app.UseWebSockets();

      app.UseSignalR("/signalr");
    }
  }
}
