using NetworkPointsWalker.Server.DTO;

namespace NetworkPointsWalker.Server.Services.Interfaces
{
    public interface IGraphService
    {
        public CrawledPathDTO GetShortestPath(Guid StartId, Guid EndId);
    }
}
