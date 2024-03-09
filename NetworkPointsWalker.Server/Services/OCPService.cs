using NetworkPointsWalker.Server.Entities;
using NetworkPointsWalker.Server.Models;
using NetworkPointsWalker.Server.Services.Interfaces;

namespace NetworkPointsWalker.Server.Services
{
    public class OCPService:IOCPService
    {
        public OCPService() { }

        public Dictionary<Guid, double> GetOCPHeuristics(OCP targetOCP, IEnumerable<OCP> OCPs)
        {
            var targetCoordinates = new Coordinates(targetOCP.GPS);
            var result = new Dictionary<Guid, double>();

            foreach (var ocp in OCPs)
            {
                var ocpCoord = new Coordinates(ocp.GPS);
                result.Add(ocp.Id, ocpCoord != targetCoordinates ? targetCoordinates.DistanceTo(ocpCoord, UnitOfLength.Kilometers) : 0);
            }

            return result;
        }

        public Dictionary<Guid, double> GetTrackHeuristics(IEnumerable<Track> Tracks)
        {
            var result = new Dictionary<Guid, double>();

            foreach (var track in Tracks)
            {
                var ocpFromCoord = new Coordinates(track.OCPFrom.GPS);
                var ocpToCoord = new Coordinates(track.OCPTo.GPS);

                result.Add(track.Id, ocpFromCoord != ocpToCoord ? ocpFromCoord.DistanceTo(ocpToCoord, UnitOfLength.Kilometers) : 0);
            }

            return result;
        }
    }
}
