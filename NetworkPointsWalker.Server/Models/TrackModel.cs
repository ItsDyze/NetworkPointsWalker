using AStarCrawler.Interfaces;

namespace NetworkPointsWalker.Server.Models
{
    public class TrackModel:IEdge
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OCPFromId { get; set; }
        public Guid OCPToId { get; set; }
        public Guid VertexA { get => OCPFromId; }
        public Guid VertexB { get => OCPToId; }
    }
}