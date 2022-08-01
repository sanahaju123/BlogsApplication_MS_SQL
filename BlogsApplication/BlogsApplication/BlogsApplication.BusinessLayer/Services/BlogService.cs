using BlogsApplication.BusinessLayer.Interfaces;
using BlogsApplication.BusinessLayer.Services.Repository;
using BlogsApplication.BusinessLayer.ViewModels;
using BlogsApplication.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogsApplication.BusinessLayer.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Blog> AddBlog(Blog blog)
        {
            return await _blogRepository.AddBlog(blog);
        }

        public async Task<Blog> DeleteBlog(int blogId)
        {
            return await _blogRepository.DeleteBlog(blogId);
        }

        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            return await _blogRepository.GetAllBlogs();
        }

        public async Task<Blog> GetBlogById(int blogId)
        {
            return await _blogRepository.GetBlogById(blogId);
        }

        public async Task<Blog> UpdateBlog(BlogViewModel model)
        {
            return await _blogRepository.UpdateBlog(model);
        }
    }
}
