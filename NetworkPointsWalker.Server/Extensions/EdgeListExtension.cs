using NetworkPointsWalker.Server.Models;
using System.Runtime.CompilerServices;

namespace NetworkPointsWalker.Server.Extensions
{
    public static class EdgeListExtension
    {
        public static IEnumerable<Edge> AddAstarHeuristics(this IEnumerable<Edge> Edges, List<Vertex> Vertices, Guid origin)
        {
            Edges = Edges.Select(x =>
            {
                x.HeuristicValue = (x.VertexA == origin) ? Vertices.Single(y => y.Id == x.VertexB).HeuristicValue : Vertices.Single(y => y.Id == x.VertexA).HeuristicValue;
                return x;
            });

            return Edges;
        }
    }
}
