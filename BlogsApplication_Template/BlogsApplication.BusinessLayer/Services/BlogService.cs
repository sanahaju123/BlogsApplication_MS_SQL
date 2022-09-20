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
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Blog> DeleteBlog(int blogId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Blog> GetBlogById(int blogId)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }

        public async Task<Blog> UpdateBlog(BlogViewModel model)
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }
    }
}
