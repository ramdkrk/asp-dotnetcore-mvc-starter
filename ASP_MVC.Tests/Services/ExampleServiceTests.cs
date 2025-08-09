using System.Collections.Generic;
using System.Threading.Tasks;
using ASP_MVC.Repositories;
using ASP_MVC.Services;
using Moq;
using Xunit;

namespace ASP_MVC.Tests.Services
{
    public sealed class ExampleServiceTests
    {
        [Fact]
        public async Task GetItemsAsync_Delegates_To_Repository()
        {
            var expected = new List<string> { "A", "B" } as IReadOnlyList<string>;
            var repo = new Mock<IExampleRepository>();
            repo.Setup(r => r.GetItemsAsync()).ReturnsAsync(expected);

            var svc = new ExampleService(repo.Object);
            var result = await svc.GetItemsAsync();

            Assert.Same(expected, result);
            repo.Verify(r => r.GetItemsAsync(), Times.Once);
        }
    }
}



