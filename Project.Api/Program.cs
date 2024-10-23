//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and peace
//=================================================

using Project.Api;

namespace Project.Api
{
    public class program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
                   webBuilder.UseStartup<Startup>());
        }
    }
}