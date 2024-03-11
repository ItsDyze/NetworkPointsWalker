using NetworkPointsWalker.Server.Entities;

namespace NetworkPointsWalker.Server.Models
{
    public class CrawledPath
    {
        public double Distance { get; set; }
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public CrawledPath() 
        { 
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
            Distance = 0;
        }

        public CrawledPath(CrawledPath path)
        {
            Distance = path.Distance;
            Edges = new List<Edge>(path.Edges);
            Vertices = new List<Vertex>(path.Vertices);
        }


    }
}
