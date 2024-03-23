using AStarCrawler.Interfaces;
using AutoMapper;
using NetworkPointsWalker.Server.Entities;

namespace NetworkPointsWalker.Server.Models
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Station, StationModel>();
            CreateMap<Track, TrackModel>();
            CreateMap<Track, IEdge>().As<TrackModel>();
            CreateMap<OCP, OCPModel>();
            CreateMap<OCP, IVertex>().As<OCPModel>();
        }
    }
}
