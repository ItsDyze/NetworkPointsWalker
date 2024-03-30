using NetworkPointsWalker.Server.Entities;

namespace NetworkPointsWalker.Server.Services.Interfaces
{
    public interface IDataService
    {
        public IEnumerable<OCP> GetOCPs();
        public IEnumerable<Track> GetTracks();
    }
}
