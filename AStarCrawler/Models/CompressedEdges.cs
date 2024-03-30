using AStarCrawler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Models
{
    internal class CompressedEdges : IEdge
    {
        public Guid Id { get; set; }
        public Guid VertexA { get; set; }
        public Guid VertexB { get; set; }
        public HashSet<Guid> IncludedEdges { get; set; }
    }
}
