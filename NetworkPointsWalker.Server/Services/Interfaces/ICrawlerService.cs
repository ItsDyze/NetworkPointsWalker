using NetworkPointsWalker.Server.Entities;
using NetworkPointsWalker.Server.Models;
using System.Diagnostics.Eventing.Reader;

namespace NetworkPointsWalker.Server.Services.Interfaces
{
    public interface ICrawlerService
    {
        public List<OCP> GetShortestPath(Guid StartId, Guid EndId);
    }
}
