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
}

