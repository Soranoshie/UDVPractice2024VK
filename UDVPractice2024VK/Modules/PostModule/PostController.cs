using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using UDVPractice2024VK.DAL.Entities;
using UDVPractice2024VK.Modules.Service;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model;

namespace UDVPractice2024VK.Modules.PostModule;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService postService;

    public PostController(IPostService postService)
    {
        this.postService = postService;
    }

    [HttpGet]
    public Task<ActionResult> Get(int count = 5)
        => postService.Get(count);


    /*private readonly int postsCount = 5;
    private static readonly int userId = 463861995;

    private static readonly string oauthToken =
        "vk1.a.IB01rtwHfkJJq8ExM9Xi1ihfpDITpNCPVjIZ-TTnAlrZ3szgr6RqjXJHtKlnezHMYnLJVWns0w26BzpPWorokwFGJU-PS7pQqVY8Fe2M5DNzAoNJeWw1HNO3YbnpHt6NgnAE4Ys2JOHtLD3hgmXp7xLIgj3rmS8GTxHjHzOsJt14CeSpGvmYiw-O9rsfXbNtpHqpgUkuq2zVXro1YhrGBg";
    
    private static readonly string accessToken =
        "0379fd1c0379fd1c0379fd1c29006e131a003790379fd1c656f6b3a616a179a7ca92ea0";

    private static readonly string apiVersion = "5.199";

    private readonly ulong appId = 51899910;
    
    [HttpGet]
    public async Task<ActionResult> GetPosts(int count = 5)
    {
        var api = new VkApi();

        var dbContext = new List<PostEntity>();
        var counter = 1;

        api.Authorize(new ApiAuthParams
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
            var posts = await api.Wall.GetAsync(new WallGetParams
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

                dbContext.Add(newEntity);
            }

            var e = LetterCounter.CountSortedChars(dbContext);
            
            return Ok(e);
        }
        catch (VkApiException ex)
        {
            return StatusCode(ex.ErrorCode, ex.Message);
        }   
    }*/
}

