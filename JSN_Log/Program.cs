using JSNLog;
using NuGet.Protocol;

namespace JSN_Log
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            var loggerFactory = app.Services.GetService<ILoggerFactory>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseJSNLog(loggerFactory, new JsnlogConfiguration()
            {
                insertJsnlogInHtmlResponses = true,
                serverSideMessageFormat = "{ 'Date': " + DateTime.UtcNow + " 'Message': %message }",
                serverSideLogger = "jslogger",
                loggers = new List<Logger> { 
                    new Logger {
                        name="a.b",
                        level="INFO",
                        userAgentRegex="MSIE 7|MSIE 8",
                    }
                }
            });

            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Phone}/{action=Index}/{id?}");

            app.Run();
        }

        //public static void Main(string[] args)
        //{
        //    var builder = WebApplication.CreateBuilder(args);

        //    var logger = LoggerFactory.Create(config =>
        //    {

        //        config.AddConsole();

        //    }).CreateLogger("Program");

        //    var app = builder.Build();

        //    app.MapGet("/", () => "Hello World!");

        //    app.MapGet("/Test", async context =>
        //    {
        //        logger.LogInformation("Testing logging in Program.cs");
        //        await context.Response.WriteAsync("Testing");
        //    });

        //    app.Run();
        //}
    }
}