using AutoMapper;
using NetworkPointsWalker.Server.Entities;

namespace NetworkPointsWalker.Server.ViewModel
{
    public class ViewModelProfile:Profile
    {
        public  ViewModelProfile() 
        {
            CreateMap<Station, StationViewModel>();
        }
    }
}
