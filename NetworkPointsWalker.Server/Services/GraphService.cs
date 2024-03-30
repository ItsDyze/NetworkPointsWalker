using AStarCrawler;
using AStarCrawler.Interfaces;
using AutoMapper;
using NetworkPointsWalker.Server.DTO;
using NetworkPointsWalker.Server.Entities;
using NetworkPointsWalker.Server.Services.Interfaces;
using System.Collections.Concurrent;

namespace NetworkPointsWalker.Server.Services
{
    public class GraphService:IGraphService
    {
        private readonly IDataService _data;
        private readonly IOCPService _ocpService;
        private readonly IMapper _mapper;
        private readonly IAStarCrawler _crawler;

        private List<OCP> OCPs;
        private List<Track> Tracks;

        public GraphService(IDataService data,
                            IOCPService ocpService,
                            IAStarCrawler crawler,
                            IMapper mapper) {  
            _data = data;
            _ocpService = ocpService;
            _mapper = mapper;
            _crawler = crawler;

            OCPs = data.GetOCPs().ToList();
            Tracks = data.GetTracks().ToList();
        }

        // Directed BFS
        public CrawledPathDTO GetShortestPath(Guid startId, Guid endId)
        {
            var awaitingInstances = new ConcurrentBag<IAStarInstance>();
            var destination = OCPs.First(x => x.Id == endId);

            HashSet<IVertex> vertices = PrepareVertices(destination);
            HashSet<IEdge> edges = _mapper.Map<HashSet<IEdge>>(Tracks);

            var crawledPath = _crawler.GetShortestPath(startId, endId, edges, vertices);
            if(crawledPath != null)
            {
                return new CrawledPathDTO()
                {
                    OCPs = _mapper.Map<IEnumerable<OCPDTO>>(crawledPath.Vertices.Select(x => OCPs.Single(y => y.Id == x.Id))).ToList(),
                    IsValid = crawledPath.IsValidSolution
                };
            }
            else
            {
                return null;
            }
            
        }

        public IEnumerable<CrawledPathDTO> GetShortestPathWithCandidates(Guid startId, Guid endId)
        {
            var awaitingInstances = new ConcurrentBag<IAStarInstance>();
            var destination = OCPs.First(x => x.Id == endId);

            HashSet<IVertex> vertices = PrepareVertices(destination);
            HashSet<IEdge> edges = _mapper.Map<HashSet<IEdge>>(Tracks);

            var crawledPaths = _crawler.GetShortestPathAndCandidates(startId, endId, edges, vertices);
            return crawledPaths.Select(p =>
            {
                var path = new CrawledPathDTO()
                {
                    OCPs = _mapper.Map<IEnumerable<OCPDTO>>(p.Vertices.Select(x => OCPs.Single(y => y.Id == x.Id))).ToList(),
                    IsValid = p.IsValidSolution
                };
                return path;
            });
        }

        public IEnumerable<CrawledPathDTO> GetAllPaths(Guid startId, Guid endId)
        {
            var awaitingInstances = new ConcurrentBag<IAStarInstance>();
            var destination = OCPs.First(x => x.Id == endId);

            HashSet<IVertex> vertices = PrepareVertices(destination);
            HashSet<IEdge> edges = _mapper.Map<HashSet<IEdge>>(Tracks);

            var crawledPaths = _crawler.GetAllPaths(startId, endId, edges, vertices, false);
            return crawledPaths.Select(p =>
            {
                var path = new CrawledPathDTO()
                {
                    OCPs = _mapper.Map<IEnumerable<OCPDTO>>(p.Vertices.Select(x => OCPs.Single(y => y.Id == x.Id))).ToList(),
                    IsValid = p.IsValidSolution
                };
                return path;
            });
        }

        private HashSet<IVertex> PrepareVertices(OCP destination)
        {
            Dictionary<Guid, double> OCPHeuristics = _ocpService.GetOCPHeuristics(destination, OCPs);

            HashSet<IVertex> vertices = _mapper.Map<HashSet<IVertex>>(OCPs).Select(vertex =>
            {
                vertex.InvertHeuristicValue = OCPHeuristics.GetValueOrDefault(vertex.Id);
                return vertex;
            }).ToHashSet();
            return vertices;
        }

        
    }
}
