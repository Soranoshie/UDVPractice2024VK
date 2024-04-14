using Microsoft.AspNetCore.Mvc;

namespace UDVPractice2024VK.Modules.Service;

public interface IPostService
{
    Task<ActionResult> Get(int count);
}