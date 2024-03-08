using NetworkPointsWalker.Server.Entities;

namespace NetworkPointsWalker.Server.Services.Interfaces
{
    public interface IDataService
    {
        public IEnumerable<Station> GetStations();
    }
}
