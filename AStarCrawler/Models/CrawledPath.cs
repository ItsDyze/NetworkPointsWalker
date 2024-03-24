using AStarCrawler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Models
{
    internal class CrawledPath:ICrawledPath
    {
        public IList<IVertex> Vertices { get; set; }
        public IList<IEdge> Edges { get; set; }
        public TimeSpan ProcessingTime {  get; set; }
        public bool IsValidSolution { get; set; } = false;

        public CrawledPath()
        {
            Vertices = new List<IVertex>();
            Edges = new List<IEdge>();
        }

        public CrawledPath(ICrawledPath path)
        {
            Edges = new List<IEdge>(path.Edges);
            Vertices = new List<IVertex>(path.Vertices);
        }
    }
}
