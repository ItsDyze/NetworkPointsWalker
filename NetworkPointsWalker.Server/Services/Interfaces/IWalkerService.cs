using System.Diagnostics.Eventing.Reader;

namespace NetworkPointsWalker.Server.Services.Interfaces
{
    public interface IWalkerService
    {
        public Dictionary<Type, List<object>> GetShortestPath(Guid StartId, Guid EndId);
    }
}
