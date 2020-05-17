using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TypedClientApp.common;
using TypedClientApp.Models;

namespace TypedClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserClient _userClient;
        private readonly PostClient _postClient;
        public HomeController(ILogger<HomeController> logger, UserClient userClient,PostClient postClient)
        {
            _logger = logger;
            _userClient = userClient;
            _postClient = postClient;
        }

        public async Task<IActionResult> Index()
        {
          var result= await GetUserData();
            var posts = await GetAllPosts();
            return View(result.Results[0]);
          
        }
        public Userinformation UserInfo { get; set; }
        public async Task<Userinformation> GetUserData()
        {
            UserInfo =await _userClient.GetData();
            return UserInfo;
        }
        public Posts posts { get; set; }
        public async Task<Posts> GetAllPosts()
        {
           posts=await _postClient.GetPosts();
            return posts;
        }
    }
}
