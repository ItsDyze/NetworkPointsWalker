using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetworkPointsWalker.Server.Services.Interfaces;
using NetworkPointsWalker.Server.ViewModel;

namespace NetworkPointsWalker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphController : ControllerBase
    {
        private readonly ILogger<GraphController> _logger;
        private readonly IDataService _dataService;
        private readonly ICrawlerService _walkerService;
        private readonly IMapper _mapper;

        public GraphController(ILogger<GraphController> logger,
                                IMapper mapper,
                                IDataService dataService,
                                ICrawlerService walkerService)
        {
            _logger = logger;
            _dataService = dataService;
            _walkerService = walkerService;
            _mapper = mapper;
        }

        [HttpGet("GetStations")]
        public IEnumerable<StationViewModel> GetStations()
        {
            return _mapper.Map<IEnumerable<StationViewModel>>(_dataService.GetStations().OrderBy(x => x.Name));
        }

        [HttpGet("GetShortestPath")]
        public CrawledPathViewModel GetShortestPath(Guid from, Guid to)
        {
            var result = _walkerService.GetShortestPath(from, to);

            return result;
        }
    }
}
