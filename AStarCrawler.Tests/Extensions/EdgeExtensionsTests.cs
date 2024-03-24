using AStarCrawler.Extensions;
using AStarCrawler.Tests.Models;

namespace AStarCrawler.Tests.Extensions
{
    public class EdgeExtensionTests
    {
        [Fact]
        public void GetOtherVertexId()
        {
            Guid guidA = Guid.NewGuid();
            Guid guidB = Guid.NewGuid();

            var data = new Edge()
            {
                Id = Guid.NewGuid(),
                VertexA = guidA,
                VertexB = guidB
            };

            Guid result = data.GetOtherVertexId(guidA);
            Assert.Equal(result, guidB);

            result = data.GetOtherVertexId(guidB);
            Assert.Equal(result, guidA);
        }
    }
}