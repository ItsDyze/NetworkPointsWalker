using NetworkPointsWalker.Server.Entities;
using NetworkPointsWalker.Server.Models;
using NetworkPointsWalker.Server.Services.Interfaces;

namespace NetworkPointsWalker.Server.Services
{
    public class WalkerService:IWalkerService
    {
        private readonly IDataService _data;
        private readonly IOCPService _ocpService;

        private List<OCP> OCPs;
        private List<Track> Tracks;

        public WalkerService(IDataService data,
                            IOCPService ocpService) {  
            _data = data;
            _ocpService = ocpService;

            OCPs = data.GetOCPs().ToList();
            Tracks = data.GetTracks().ToList();
        }

        public Dictionary<Type, List<object>> GetShortestPath(Guid StartId, Guid EndId)
        {
            var result = new Dictionary<Type, List<object>>();

            Dictionary<Guid, double> OCPHeuristics = _ocpService.GetOCPHeuristics(OCPs.First(x => x.Id == EndId), OCPs);
            Dictionary<Guid, double> TrackHeuristics = _ocpService.GetTrackHeuristics(Tracks);

            List<Vertex> vertices = OCPs.Select(x => new Vertex() { Id = x.Id, HeuristicValue = OCPHeuristics.GetValueOrDefault(x.Id) }).ToList();
            List<Edge> edges = Tracks.Select(x => new Edge() { Id = x.Id, VertexA = x.OCPFromId, VertexB = x.OCPToId, HeuristicValue = TrackHeuristics.GetValueOrDefault(x.Id) }).ToList();



            return result;
        }

        // Directed BFS
        private Dictionary<Type, List<object>> AStarCrawler(Vertex StartVertex, List<Vertex> Vertices, List<Guid> ExploredVertices, List<Edge> Edges, Dictionary<Type, List<object>> Path)
        {
            // From the start vertex
            var possibleEdges = Edges.Where(x => x.VertexA == )
            // Evaluate possible edges

            // Order edges by lowest target vertex heuristics

            // Foreach edges repeat

                // If null -> Wrongpath
                // If List<obj> -> GoodPath
        }

        private void DjikstraCrawler()
        {

        }
    }
}
