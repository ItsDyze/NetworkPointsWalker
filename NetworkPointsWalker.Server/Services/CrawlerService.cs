using AutoMapper;
using NetworkPointsWalker.Server.Entities;
using NetworkPointsWalker.Server.Extensions;
using NetworkPointsWalker.Server.Models;
using NetworkPointsWalker.Server.Services.CrawlerUtils;
using NetworkPointsWalker.Server.Services.Interfaces;
using NetworkPointsWalker.Server.ViewModel;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace NetworkPointsWalker.Server.Services
{
    public class CrawlerService:ICrawlerService
    {
        private readonly IDataService _data;
        private readonly IOCPService _ocpService;
        private readonly IMapper _mapper;

        private List<OCP> OCPs;
        private List<Track> Tracks;

        public CrawlerService(IDataService data,
                            IOCPService ocpService,
                            IMapper mapper) {  
            _data = data;
            _ocpService = ocpService;
            _mapper = mapper;

            OCPs = data.GetOCPs().ToList();
            Tracks = data.GetTracks().ToList();
        }

        // Directed BFS
        public CrawledPathViewModel GetShortestPath(Guid StartId, Guid EndId)
        {
            var destination = OCPs.First(x => x.Id == EndId);

            Dictionary<Guid, double> OCPHeuristics = _ocpService.GetOCPHeuristics(destination, OCPs);
            Dictionary<Guid, double> TrackHeuristics = _ocpService.GetTrackHeuristics(Tracks);

            List<Vertex> vertices = OCPs.Select(x => new Vertex() { Id = x.Id, Name = x.Name, HeuristicValue = OCPHeuristics.GetValueOrDefault(x.Id) }).ToList();
            List<Edge> edges = Tracks.Select(x => new Edge() { Id = x.Id, VertexA = x.OCPFromId, VertexB = x.OCPToId}).ToList();

            var startVertex = vertices.Single(x => x.Id == StartId);
            var endVertex = vertices.Single(x => x.Id == EndId);
            var awaitingCrawlers = new ConcurrentBag<AStarCrawler>();

            AStarCrawler firstCrawler = new AStarCrawler(startVertex, endVertex, vertices, new List<Guid>(), edges, new CrawledPath(), awaitingCrawlers, 0 + startVertex.HeuristicValue, 0);

            firstCrawler.Run();

            bool foundPath = false;

            while(awaitingCrawlers.Count(x => !x.Done) > 0 && !foundPath)
            {
                var minHeuristic = awaitingCrawlers.Where(x => !x.Done).Min(x => x.HeuristicValue);
                var crawlerToProcess = awaitingCrawlers.First(y => !y.Done && y.HeuristicValue == minHeuristic);
                foundPath = crawlerToProcess.Run();
                if(foundPath)
                {
                    var crawledPath = crawlerToProcess.GetPath();
                    var result = new CrawledPathViewModel(_mapper.Map<IEnumerable<OCPViewModel>>( crawledPath.Vertices.Select(x => OCPs.Single(y => y.Id == x.Id))).ToList(), crawledPath.Distance);
                    return result;
                }
            }

            return null;
        }

        private void DjikstraCrawler()
        {

        }
    }
}
