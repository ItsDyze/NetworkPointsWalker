using NetworkPointsWalker.Server.Entities;

namespace NetworkPointsWalker.Server.Services.Interfaces
{
    public interface IOCPService
    {
        Dictionary<Guid, double> GetOCPHeuristics(OCP targetOCP, IEnumerable<OCP> OCPs);
        Dictionary<Guid, double> GetTrackHeuristics(IEnumerable<Track> Tracks);
    }
}
