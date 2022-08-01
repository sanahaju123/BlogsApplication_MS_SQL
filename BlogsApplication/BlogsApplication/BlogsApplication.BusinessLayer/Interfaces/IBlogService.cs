using BlogsApplication.BusinessLayer.ViewModels;
using BlogsApplication.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogsApplication.BusinessLayer.Interfaces
{
    public interface IBlogService
    {
        Task<Blog> AddBlog(Blog blog);
        Task<Blog> GetBlogById(int blogId);
        Task<Blog> UpdateBlog(BlogViewModel model);
        Task<Blog> DeleteBlog(int blogId);
        Task<IEnumerable<Blog>> GetAllBlogs();
    }
}
