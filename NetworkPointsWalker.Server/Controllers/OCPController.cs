using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetworkPointsWalker.Server.DTO;
using NetworkPointsWalker.Server.Services.Interfaces;
namespace NetworkPointsWalker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OCPController : ControllerBase
    {
        private readonly ILogger<OCPController> _logger;
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public OCPController(ILogger<OCPController> logger,
                                IMapper mapper,
                                IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<OCPDTO> GetOCPs()
        {
            return _mapper.Map<IEnumerable<OCPDTO>>(_dataService.GetOCPs().OrderBy(x => x.Name));
        }
    }
}
