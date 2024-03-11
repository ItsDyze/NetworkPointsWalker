using AutoMapper;
using NetworkPointsWalker.Server.Entities;
using NetworkPointsWalker.Server.Models;

namespace NetworkPointsWalker.Server.ViewModel
{
    public class ViewModelProfile:Profile
    {
        public  ViewModelProfile() 
        {
            CreateMap<Station, StationViewModel>();
            CreateMap<OCP, OCPViewModel>()
                .ForMember(x => x.Coordinates, y => y.MapFrom(ocp => new Coordinates(ocp.GPS)));
            CreateMap<Coordinates, CoordinatesViewModel>();
        }
    }
}
