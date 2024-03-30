using Microsoft.EntityFrameworkCore;
using NetworkPointsWalker.Server.Entities;
using NetworkPointsWalker.Server.Services.Interfaces;

namespace NetworkPointsWalker.Server.Services
{
    public class DataService : IDataService
    {
        private readonly AppDbContext _db;

        public DataService(AppDbContext db) 
        {
            _db = db;
        }

        public IEnumerable<OCP> GetOCPs()
        {
            return _db.OCPs;
        }

        public IEnumerable<Track> GetTracks()
        {
            return _db.Tracks;
        }
    }
}
