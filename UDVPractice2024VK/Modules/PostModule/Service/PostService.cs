using Microsoft.AspNetCore.Mvc;
using UDVPractice2024VK.DAL;
using UDVPractice2024VK.DAL.Entities;
using UDVPractice2024VK.Modules.LetterModule;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model;

namespace UDVPractice2024VK.Modules.Service;

public class PostService : ControllerBase, IPostService
{
    private readonly ApplicationDbContext context;
    private readonly VkApi vkApi;
    private readonly List<PostEntity> postEntities;
    private int counter = 1;
    private readonly ulong appId = 51899910;
    private static readonly string oauthToken =
        "vk1.a.IB01rtwHfkJJq8ExM9Xi1ihfpDITpNCPVjIZ-TTnAlrZ3szgr6RqjXJHtKlnezHMYnLJVWns0w26BzpPWorokwFGJU-PS7pQqVY8Fe2M5DNzAoNJeWw1HNO3YbnpHt6NgnAE4Ys2JOHtLD3hgmXp7xLIgj3rmS8GTxHjHzOsJt14CeSpGvmYiw-O9rsfXbNtpHqpgUkuq2zVXro1YhrGBg";
    private static readonly int userId = 463861995;
    
    public PostService(ApplicationDbContext context, VkApi vkApi, List<PostEntity> postEntities)
    {
        this.context = context;
        this.vkApi = vkApi;
        this.postEntities = postEntities;
    }
    
    public async Task<ActionResult> Get(int count)
    {
        vkApi.Authorize(new ApiAuthParams
        {
            Login = "+79521360881",
            Password = "NoFCaL53",
            ApplicationId = appId,
            AccessToken = oauthToken,
            Settings = Settings.All,
            UserId = userId
        });
        
        try
        {
            var posts = await vkApi.Wall.GetAsync(new WallGetParams
            {
                Count = (ulong)count,
            });
            
            foreach (var wallPost in posts.WallPosts.Reverse())
            {
                var newEntity = new PostEntity
                {
                    Text = wallPost.Text,
                    OriginalOrder = counter++,
                };

                postEntities.Add(newEntity);
            }

            var result = LetterCounter.CountSortedChars(postEntities);

            var entities = result.Select(entity => new LetterDictionaryDTO
            {
                Letter = entity.Key,
                Count = entity.Value
            }).ToList();
            
            context.LetterDictionary.AddRange(entities);
            await context.SaveChangesAsync();
            
            return Ok(result);
        }
        catch (VkApiException ex)
        {
            return StatusCode(ex.ErrorCode, ex.Message);
        }
    }
}