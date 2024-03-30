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
            CreateMap<OCP, OCPDTO>()
                .ForMember(x => x.Coordinates, y => y.MapFrom(ocp => new CoordinatesModel(ocp.GPS)));
            CreateMap<CoordinatesModel, CoordinatesDTO>();
        }
    }
}
