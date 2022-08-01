using BlogsApplication.BusinessLayer.ViewModels;
using BlogsApplication.DataLayer;
using BlogsApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsApplication.BusinessLayer.Services.Repository
{
    public class BlogRepository:IBlogRepository
    {
        private readonly BlogDbContext _blogDbContext;
        public BlogRepository(BlogDbContext blogsDbContext)
        {
            _blogDbContext = blogsDbContext;
        }

        public async Task<Blog> AddBlog(Blog blog)
        {
            try
            {
                var result = await _blogDbContext.Blogs.AddAsync(blog);
                await _blogDbContext.SaveChangesAsync();
                return blog;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Blog> DeleteBlog(int blogId)
        {
            var blog = await _blogDbContext.Blogs.FindAsync(blogId);
            try
            {
                _blogDbContext.Blogs.Remove(blog);
                await _blogDbContext.SaveChangesAsync();
                return blog;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            try
            {
                var result = _blogDbContext.Blogs.
                OrderByDescending(x => x.BlogId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Blog> GetBlogById(int blogId)
        {
            try
            {
                return await _blogDbContext.Blogs.FindAsync(blogId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Blog> UpdateBlog(BlogViewModel model)
        {
            var blog = await _blogDbContext.Blogs.FindAsync(model.BlogId);
            try
            {
                blog.Title = model.Title;
                blog.Content = model.Content;
                _blogDbContext.Blogs.Update(blog);
                await _blogDbContext.SaveChangesAsync();
                return blog;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
