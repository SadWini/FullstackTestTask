using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Web;

public class Program
{
    public static async Task Main(string[] args)
    {
        await Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureKestrel(op=>{
                    op.ListenLocalhost(7056, o=> o.Protocols = HttpProtocols.Http1);
                    op.ListenLocalhost(5001, o => o.Protocols = HttpProtocols.Http2);
                });
                webBuilder.UseStartup<Startup>();
            }).Build().RunAsync();
    }
}