using NetworkPointsWalker.Server.Entities;
using NetworkPointsWalker.Server.Models;
using NetworkPointsWalker.Server.ViewModel;
using System.Diagnostics.Eventing.Reader;

namespace NetworkPointsWalker.Server.Services.Interfaces
{
    public interface ICrawlerService
    {
        public CrawledPathViewModel GetShortestPath(Guid StartId, Guid EndId);
    }
}
