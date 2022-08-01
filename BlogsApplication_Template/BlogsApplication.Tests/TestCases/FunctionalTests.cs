using BlogsApplication.BusinessLayer.Interfaces;
using BlogsApplication.BusinessLayer.Services;
using BlogsApplication.BusinessLayer.Services.Repository;
using BlogsApplication.BusinessLayer.ViewModels;
using BlogsApplication.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace BlogsApplication.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IBlogService _blogServices;
        public readonly Mock<IBlogRepository> blogservice = new Mock<IBlogRepository>();
        private readonly Blog _blog;
        private static string type = "Functional";
        public FunctionalTests(ITestOutputHelper output)
        {
            _blogServices = new BlogService(blogservice.Object);
            _output = output;

            _blog = new Blog
            {
                BlogId = 1,
                Content = "MyBlog",
                Title = "MyTitle",
            };
        }

        /// <summary>
        /// Test to Add a new Blog.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Add_Blog()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                blogservice.Setup(repos => repos.AddBlog(_blog)).ReturnsAsync(_blog);
                var result = await _blogServices.AddBlog(_blog);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// Test to Update a Blog by Blog Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_Blog()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateBlog = new BlogViewModel()
            {
                BlogId = 1,
                Title = "BlogTitle",
                Content = "Pending",
            };
            //Act
            try
            {
                blogservice.Setup(repos => repos.UpdateBlog(_updateBlog)).ReturnsAsync(_blog);
                var result = await _blogServices.UpdateBlog(_updateBlog);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// Test to Get all Blogs
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetAll_Blogs()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                blogservice.Setup(repos => repos.GetAllBlogs());
                var result = await _blogServices.GetAllBlogs();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to get Blog By Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetBlogById()
        {
            //Arrange
            var res = false;
            int blogId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                blogservice.Setup(repos => repos.GetBlogById(blogId)).ReturnsAsync(_blog);
                var result = await _blogServices.GetBlogById(blogId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Delete Blog By Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_DeleteBlogById()
        {
            //Arrange
            var res = false;
            int blogId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                blogservice.Setup(repos => repos.DeleteBlog(blogId)).ReturnsAsync(_blog);
                var result = await _blogServices.DeleteBlog(blogId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
    }
}