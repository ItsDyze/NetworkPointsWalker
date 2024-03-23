using AStarCrawler.Interfaces;

namespace NetworkPointsWalker.Server.Models
{
    public class OCPModel:IVertex
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double InvertHeuristicValue { get; set; }
        public CoordinatesModel Coordinates { get; set; }
    }
}
