using NetworkPointsWalker.Server.Extensions;
using NetworkPointsWalker.Server.Models;
using System.Collections.Concurrent;

namespace NetworkPointsWalker.Server.Services.CrawlerUtils
{
    public class AStarCrawler
    {
        Vertex StartVertex;
        Vertex EndVertex;
        List<Vertex> Vertices;
        List<Guid> ExploredVertices;
        List<Edge> Edges;
        CrawledPath CurrentPath;

        public double Distance = 0;
        public double HeuristicValue = 0;
        public bool Done = false;

        ConcurrentBag<AStarCrawler> AwaitingCrawlers;

        public AStarCrawler(Vertex startVertex, Vertex endVertex, List<Vertex> vertices, List<Guid> exploredVertices, List<Edge> edges, CrawledPath currentPath, ConcurrentBag<AStarCrawler> awaitingCrawlers, double heuristicValue, double distance)
        {
            StartVertex = startVertex;
            EndVertex = endVertex;
            Vertices = vertices;
            ExploredVertices = exploredVertices;
            Edges = edges;
            CurrentPath = currentPath;
            AwaitingCrawlers = awaitingCrawlers;
            HeuristicValue = heuristicValue;
            Distance = distance;
        }

        public CrawledPath GetPath()
        {
            return CurrentPath;
        }

        public bool Run()
        {
            Done = true;
            CurrentPath.Vertices.Add(StartVertex); 
            ExploredVertices.Add(StartVertex.Id);

            if (StartVertex == EndVertex)
            {
                return true;
            }

            var orderedEdges = Edges.Where(x => (x.VertexA == StartVertex.Id || x.VertexB == StartVertex.Id) && !ExploredVertices.Contains(x.TheOtherVertex(StartVertex.Id)))
                                        .OrderBy(x => x.HeuristicValue);

            foreach (var edge in orderedEdges)
            {
                var newPath = new CrawledPath(CurrentPath);
                newPath.Edges.Add(edge);
                newPath.Distance += edge.HeuristicValue;
                var theOtherVertex = Vertices.Single(x => x.Id == edge.TheOtherVertex(StartVertex.Id));
                AwaitingCrawlers.Add(new AStarCrawler(theOtherVertex, EndVertex, Vertices, ExploredVertices, Edges, newPath, AwaitingCrawlers, HeuristicValue + theOtherVertex.HeuristicValue, Distance + edge.HeuristicValue));
            }

            return false;
        }
    }
}
