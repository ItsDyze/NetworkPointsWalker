using AStarCrawler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Extensions
{
    public static class EdgeExtension
    {
        public static Guid GetOtherVertexId(this IEdge edge, Guid vertexId)
        {
            return edge.VertexA == vertexId ? edge.VertexB : edge.VertexA;
        }
    }
}
