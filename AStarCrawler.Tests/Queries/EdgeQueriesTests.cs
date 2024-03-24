using AStarCrawler.Interfaces;
using AStarCrawler.Queries;
using AStarCrawler.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Tests.Queries
{
    public class EdgeQueriesTests
    {

        [Fact]
        public void FromOrigin()
        {
            Guid origin = Guid.NewGuid();
            var originConnectedEdgeA = new Edge()
            {
                Id = Guid.NewGuid(),
                VertexA = origin,
                VertexB = Guid.NewGuid()
            };
            var originConnectedEdgeB = new Edge()
            {
                Id = Guid.NewGuid(),
                VertexA = Guid.NewGuid(),
                VertexB = origin
            };
            var notConnectedEdgeC = new Edge()
            {
                Id = Guid.NewGuid(),
                VertexA = Guid.NewGuid(),
                VertexB = Guid.NewGuid()
            };
            var notConnectedEdgeD = new Edge()
            {
                Id = Guid.NewGuid(),
                VertexA = Guid.NewGuid(),
                VertexB = Guid.NewGuid()
            };

            IEnumerable<Edge> edges = new List<Edge>()
            {
                originConnectedEdgeA, originConnectedEdgeB,
                notConnectedEdgeC, notConnectedEdgeD
            };

            var filteredEdges = edges.FromOrigin(origin);

            Assert.Contains(originConnectedEdgeA, filteredEdges);
            Assert.Contains(originConnectedEdgeB, filteredEdges);
            Assert.DoesNotContain(notConnectedEdgeC, filteredEdges);
            Assert.DoesNotContain(notConnectedEdgeD, filteredEdges);
        }


        [Fact]
        public void NotExplored()
        {
            Guid origin = Guid.NewGuid();
            Guid exploredA = Guid.NewGuid();
            Guid exploredB = Guid.NewGuid();
            Guid notExploredA = Guid.NewGuid();
            Guid notExploredB = Guid.NewGuid();

            HashSet<IVertex> exploredVertices = new HashSet<IVertex>()
            {
                new Vertex()
                {
                    Id = exploredA
                },
                new Vertex()
                {
                    Id = exploredB
                },
            };

            var exploredEdgeA = new Edge()
            {
                Id = Guid.NewGuid(),
                VertexA = exploredA,
                VertexB = origin
            };
            var exploredEdgeB = new Edge()
            {
                Id = Guid.NewGuid(),
                VertexA = origin,
                VertexB = exploredB
            };
            var notExploredEdgeC = new Edge()
            {
                Id = Guid.NewGuid(),
                VertexA = origin,
                VertexB = notExploredA
            };
            var notExploredEdgeD = new Edge()
            {
                Id = Guid.NewGuid(),
                VertexA = origin,
                VertexB = notExploredB
            };

            IEnumerable<Edge> edges = new List<Edge>()
            {
                exploredEdgeA, exploredEdgeB, notExploredEdgeC, notExploredEdgeD
            };

            var filteredEdges = edges.NotExplored(exploredVertices, origin);

            Assert.Contains(notExploredEdgeC, filteredEdges);
            Assert.Contains(notExploredEdgeD, filteredEdges);
            Assert.DoesNotContain(exploredEdgeA, filteredEdges);
            Assert.DoesNotContain(exploredEdgeB, filteredEdges);
        }
    }
}
