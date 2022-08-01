using BlogsApplication.BusinessLayer.Interfaces;
using BlogsApplication.BusinessLayer.Services;
using BlogsApplication.BusinessLayer.Services.Repository;
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
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IBlogService _blogServices;
        public readonly Mock<IBlogRepository> blogservice = new Mock<IBlogRepository>();
        private readonly Blog _blog;
        private static string type = "Exception";
        public ExceptionalTests(ITestOutputHelper output)
        {
            _blogServices = new BlogService(blogservice.Object);
            _output = output;

            _blog = new Blog
            {
                BlogId = 1,
                Content="MyContent",
                Title = "MyTitle",
            };
        }

        /// <summary>
        /// Test to validate if invalid blog id is passed it will return false
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_IfInvalidBlogIdIsPassed()
        {
            //Arrange
            bool res = false;
            _blog.BlogId = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                blogservice.Setup(repo => repo.AddBlog(_blog)).ReturnsAsync(_blog);
                var result = await _blogServices.AddBlog(_blog);
                if (result == null || result.BlogId < 1)
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
