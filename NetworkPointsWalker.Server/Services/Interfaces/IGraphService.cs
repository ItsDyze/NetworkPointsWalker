﻿using NetworkPointsWalker.Server.DTO;

namespace NetworkPointsWalker.Server.Services.Interfaces
{
    public interface IGraphService
    {
        public CrawledPathDTO GetShortestPath(Guid StartId, Guid EndId);
        IEnumerable<CrawledPathDTO> GetShortestPathWithCandidates(Guid startId, Guid endId);
        IEnumerable<CrawledPathDTO> GetAllPaths(Guid startId, Guid endId);
    }
}
