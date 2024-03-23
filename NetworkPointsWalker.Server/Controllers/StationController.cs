using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetworkPointsWalker.Server.DTO;
using NetworkPointsWalker.Server.Services.Interfaces;
namespace NetworkPointsWalker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StationController : ControllerBase
    {
        private readonly ILogger<GraphController> _logger;
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public StationController(ILogger<GraphController> logger,
                                IMapper mapper,
                                IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet("GetStations")]
        public IEnumerable<StationDTO> GetStations()
        {
            return _mapper.Map<IEnumerable<StationDTO>>(_dataService.GetStations().OrderBy(x => x.Name));
        }
    }
}
