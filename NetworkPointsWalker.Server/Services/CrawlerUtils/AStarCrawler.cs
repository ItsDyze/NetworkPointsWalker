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
        List<Vertex> Path;
        

        public double HeuristicValue = 0;
        public bool Done = false;

        ConcurrentBag<AStarCrawler> AwaitingCrawlers;

        public AStarCrawler(Vertex startVertex, Vertex endVertex, List<Vertex> vertices, List<Guid> exploredVertices, List<Edge> edges, List<Vertex> path, ConcurrentBag<AStarCrawler> awaitingCrawlers)
        {
            StartVertex = startVertex;
            EndVertex = endVertex;
            Vertices = vertices;
            ExploredVertices = exploredVertices;
            Edges = edges;
            Path = path;
            AwaitingCrawlers = awaitingCrawlers;
            HeuristicValue = startVertex.HeuristicValue;
        }

        public List<Vertex> GetPath()
        {
            return Path;
        }

        public bool Run()
        {
            Done = true;
            Path.Add(StartVertex); 
            ExploredVertices.Add(StartVertex.Id);

            if (StartVertex == EndVertex)
            {
                return true;
            }

            var orderedEdges = Edges.Where(x => (x.VertexA == StartVertex.Id || x.VertexB == StartVertex.Id) && !ExploredVertices.Contains(x.TheOtherVertex(StartVertex.Id)))
                                        .AddAstarHeuristics(Vertices, StartVertex.Id)
                                        .OrderBy(x => x.HeuristicValue);

            foreach (var edge in orderedEdges)
            {
                var theOtherVertex = Vertices.Single(x => x.Id == edge.TheOtherVertex(StartVertex.Id));
                AwaitingCrawlers.Add(new AStarCrawler(theOtherVertex, EndVertex, Vertices, ExploredVertices, Edges, Path, AwaitingCrawlers));
            }

            return false;
        }

        public override string ToString()
        {
            return StartVertex.Name + "("+ String.Join('>', Path.Select(x => Vertices.Single(y => y.Id == x.Id).Name)) +")";
        }
    }
}
