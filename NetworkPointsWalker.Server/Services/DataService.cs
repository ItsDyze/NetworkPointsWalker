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

        public IEnumerable<Station> GetStations()
        {
            return _db.Stations;
        }
    }
}
