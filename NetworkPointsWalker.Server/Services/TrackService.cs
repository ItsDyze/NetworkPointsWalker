using NetworkPointsWalker.Server.Services.Interfaces;

namespace NetworkPointsWalker.Server.Services
{
    public class TrackService:ITrackService
    {
        private readonly IOCPService _ocpService;
        public TrackService(IOCPService ocpService) 
        {
            _ocpService = ocpService;
        }
    }
}
