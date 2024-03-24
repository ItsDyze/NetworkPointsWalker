using AStarCrawler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Tests.Models
{
    internal class Edge : IEdge
    {
        public Guid Id { get; set; }

        public Guid VertexA { get; set; }

        public Guid VertexB { get; set; }
    }
}
