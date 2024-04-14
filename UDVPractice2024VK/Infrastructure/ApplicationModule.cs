using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UDVPractice2024VK.DAL;

namespace UDVPractice2024VK.Infrastructure;

public class ApplicationModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        services.AddDbContext<ApplicationDbContext>();
        return services;
    }   
}