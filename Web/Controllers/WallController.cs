using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Dto;

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WallController : ControllerBase
    {
        [HttpGet]
        [Route("posts")]
        public async Task<ICollection<PostDto>> GetPosts()
        {
            var postsDto = new List<PostDto>();
            var user1 = new UserDto
            {
                Id = 1,
                Name = "Robert"
            };
            var post1 = new PostDto
            {
                Message = "Hello World",
                Created = DateTime.Now,
                Id = 1,
                User = user1
            };
            postsDto.Add(post1);
            return postsDto;
        }
    }
}
