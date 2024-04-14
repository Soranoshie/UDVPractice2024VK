using UDVPractice2024VK.DAL.Entities;
using UDVPractice2024VK.Infrastructure;
using UDVPractice2024VK.Modules.Service;

namespace UDVPractice2024VK.Modules.PostModule;

public class PostModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddSingleton<VkNet.VkApi>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<List<PostEntity>>();

        return services;
    }
}