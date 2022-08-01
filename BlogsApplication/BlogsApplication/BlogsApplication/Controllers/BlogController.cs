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
    //[Route("api/[controller]")]
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
            var blogExists = await _blogService.GetBlogById(model.BlogId);
            if (blogExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Blog already exists!" });
            Blog blog = new Blog()
            {
                BlogId = model.BlogId,
                Content = model.Content,
                Title = model.Title,
            };
            var result = await _blogService.AddBlog(blog);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Blog creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Blog created successfully!" });

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
            var blog = await _blogService.GetBlogById(model.BlogId);
            if (blog == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Blog With Id = {model.BlogId} cannot be found" });
            }
            else
            {
                var result = await _blogService.UpdateBlog(model);
                return Ok(new Response { Status = "Success", Message = "Blog Edited successfully!" });
            }
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
            var blog = await _blogService.GetBlogById(blogId);
            if (blog == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Blog With Id = {blogId} cannot be found" });
            }
            else
            {
                var result = await _blogService.DeleteBlog(blogId);
                return Ok(new Response { Status = "Success", Message = "Blog deleted successfully!" });
            }
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
            var blog = await _blogService.GetBlogById(blogId);
            if (blog == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Blog With Id = {blogId} cannot be found" });
            }
            else
            {
                return Ok(blog);
            }
        }

        /// <summary>
        /// Get List of All Blogs.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/blogservice/all")]
        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            return await _blogService.GetAllBlogs();
        }
    }
}
