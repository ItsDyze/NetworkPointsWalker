using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetworkPointsWalker.Server.DTO;
using NetworkPointsWalker.Server.Services.Interfaces;
namespace NetworkPointsWalker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphController : ControllerBase
    {
        private readonly ILogger<GraphController> _logger;
        private readonly IGraphService _graphService;
        private readonly IMapper _mapper;

        public GraphController(ILogger<GraphController> logger,
                                IMapper mapper,
                                IDataService dataService,
                                IGraphService graphService)
        {
            _logger = logger;
            _graphService = graphService;
            _mapper = mapper;
        }

        [HttpGet("GetShortestPath")]
        public CrawledPathDTO GetShortestPath(Guid from, Guid to)
        {
            var result = _graphService.GetShortestPath(from, to);

            return result;
        }

        [HttpGet("GetShortestPathWithCandidates")]
        public IEnumerable<CrawledPathDTO> GetShortestPathWithCandidates(Guid from, Guid to)
        {
            var result = _graphService.GetShortestPathWithCandidates(from, to);

            return result;
        }

        [HttpGet("GetAllPaths")]
        public IEnumerable<CrawledPathDTO> GetAllPaths(Guid from, Guid to)
        {
            var result = _graphService.GetAllPaths(from, to);

            return result;
        }
    }
}
