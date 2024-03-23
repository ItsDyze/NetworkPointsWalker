using AutoMapper;
using NetworkPointsWalker.Server.DTO;
using NetworkPointsWalker.Server.Entities;
using NetworkPointsWalker.Server.Models;

namespace NetworkPointsWalker.Server.DTO
{
    public class DTOProfile:Profile
    {
        public  DTOProfile() 
        {
            CreateMap<StationModel, StationDTO>();
            // Missing a layer between data and controller to do it clean without skipping step
            CreateMap<Station, StationDTO>();


            CreateMap<OCP, OCPDTO>()
                .ForMember(x => x.Coordinates, y => y.MapFrom(ocp => new CoordinatesModel(ocp.GPS)));
            CreateMap<CoordinatesModel, CoordinatesDTO>();
        }
    }
}
