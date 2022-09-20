using BlogsApplication.BusinessLayer.Interfaces;
using BlogsApplication.BusinessLayer.ViewModels;
using BlogsApplication.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogsApplication.Controllers
{
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        /// <summary>
        /// Add Blog By Id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/blogservice/add")]
        [AllowAnonymous]
        public async Task<IActionResult> AddBlog([FromBody] BlogViewModel model)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update Blog By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("/blogservice/update")]
        public async Task<IActionResult> UpdateBlog([FromBody] BlogViewModel model)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }


        /// <summary>
        /// Delete Blog By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/blogservice/delete/{blogId}")]
        public async Task<IActionResult> DeleteBlog(int blogId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Blog By Blog Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/blogservice/get/{blogId}")]
        public async Task<IActionResult> GetBlogById(int blogId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get List of All Blogs.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/blogservice/all")]
        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }
    }
}
