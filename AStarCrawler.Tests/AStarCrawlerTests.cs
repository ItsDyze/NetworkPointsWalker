using AStarCrawler.Interfaces;
using AStarCrawler.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Tests
{
    public class AStarCrawlerTests
    {
        /*
         * Created a cross like graph with arms at each angles
         * 
         *                F
         *                |
         *                p1
         *                |  \
         *           a3 - a1 - p2 - T
         *                |  
         *                a2
         */
        [Fact]
        public void GetShortestPath()
        {
            Guid from = Guid.NewGuid();
            Guid to = Guid.NewGuid();
            Guid passage1 = Guid.NewGuid();
            Guid passage2 = Guid.NewGuid();
            Guid avoid1 = Guid.NewGuid();
            Guid avoid2 = Guid.NewGuid();
            Guid avoid3 = Guid.NewGuid();

            // Heuristices set as number of hop from destination
            HashSet<IVertex> vertices = new HashSet<IVertex>()
            {
                new Vertex()
                {
                    Id = from,
                    InvertHeuristicValue = 3
                },
                new Vertex()
                {
                    Id = passage1,
                    InvertHeuristicValue = 2
                },
                new Vertex()
                {
                    Id = passage2,
                    InvertHeuristicValue = 1
                },
                new Vertex()
                {
                    Id = to,
                    InvertHeuristicValue = 0
                },
                new Vertex()
                {
                    Id = avoid1,
                    InvertHeuristicValue = 2
                },
                new Vertex()
                {
                    Id = avoid2,
                    InvertHeuristicValue = 3
                },
                new Vertex()
                {
                    Id = avoid3,
                    InvertHeuristicValue = 3
                }
            };

            // Reusing the Vertex ID as interesting Edge ID
            HashSet<IEdge> edges = new HashSet<IEdge>()
            {
                new Edge()
                {
                    Id = from,
                    VertexA = from,
                    VertexB = passage1,
                },
                new Edge()
                {
                    Id = passage1,
                    VertexA = passage1,
                    VertexB = passage2,
                },
                new Edge()
                {
                    Id = passage2,
                    VertexA = passage2,
                    VertexB = to,
                },
                new Edge()
                {
                    Id = avoid1,
                    VertexA = avoid1,
                    VertexB = passage1,
                },
                new Edge()
                {
                    Id = Guid.NewGuid(),
                    VertexA = avoid1,
                    VertexB = passage2,
                },
                new Edge()
                {
                    Id = avoid2,
                    VertexA = avoid2,
                    VertexB = avoid1,
                },
                new Edge()
                {
                    Id = avoid3,
                    VertexA = avoid3,
                    VertexB = avoid1,
                },
            };

            List<IVertex> expectedPath = [
                vertices.Single(v => v.Id == from),
                vertices.Single(v => v.Id == passage1),
                vertices.Single(v => v.Id == passage2),
                vertices.Single(v => v.Id == to),
            ];

            var crawler = new AStarCrawler();
            var result = crawler.GetShortestPath(from, to, edges, vertices);

            Assert.NotNull(result);
            Assert.True(result.IsValidSolution);
            Assert.Equal(expectedPath, result.Vertices);
        }

    }
}
