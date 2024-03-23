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
        private readonly IDataService _dataService;
        private readonly IGraphService _walkerService;
        private readonly IMapper _mapper;

        public GraphController(ILogger<GraphController> logger,
                                IMapper mapper,
                                IDataService dataService,
                                IGraphService walkerService)
        {
            _logger = logger;
            _dataService = dataService;
            _walkerService = walkerService;
            _mapper = mapper;
        }

        [HttpGet("GetStations")]
        public IEnumerable<StationDTO> GetStations()
        {
            return _mapper.Map<IEnumerable<StationDTO>>(_dataService.GetStations().OrderBy(x => x.Name));
        }

        [HttpGet("GetShortestPath")]
        public CrawledPathDTO GetShortestPath(Guid from, Guid to)
        {
            var result = _walkerService.GetShortestPath(from, to);

            return result;
        }
    }
}
