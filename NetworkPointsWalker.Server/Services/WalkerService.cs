using NetworkPointsWalker.Server.Models;
using NetworkPointsWalker.Server.Services.Interfaces;

namespace NetworkPointsWalker.Server.Services
{
    public class WalkerService:IWalkerService
    {
        private readonly IDataService _data;
        private List<Vertex> _vertices;
        private List<Edge> _edges;

        public WalkerService(IDataService data) {  
            _data = data;

            var OCPs = data.GetOCPs();
            var Tracks = data.GetTracks();

            _vertices = OCPs.Select(x => new Vertex() { Id = x.Id }).ToList();
            _edges = Tracks.Select(x => new Edge() { Id = x.Id, VertexA = x.OCPFromId, VertexB = x.OCPToId }).ToList();
        }


    }
}
