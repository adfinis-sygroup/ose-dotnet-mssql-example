using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", optional: true)
      .Build();

    var host = new WebHostBuilder()
      .UseKestrel()
      .UseConfiguration(builder)
      .UseContentRoot(Directory.GetCurrentDirectory())
      .UseStartup<Startup>()
      .Build();

    host.Run();

  }

}
