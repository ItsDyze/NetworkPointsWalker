using AStarCrawler.Extensions;
using AStarCrawler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Queries
{
    public static class EdgeFilters
    {
        public static IEnumerable<IEdge> FromOrigin(this IEnumerable<IEdge> edges, Guid originId)
        {
            return edges.Where(e => (e.VertexA == originId || e.VertexB == originId));
        }

        public static IEnumerable<IEdge> NotExplored(this IEnumerable<IEdge> edges, HashSet<Guid> exploredVertices)
        {
            return edges.Where(e => !exploredVertices.Any(v => v == e.VertexB || v == e.VertexA));
        }
    }
}
