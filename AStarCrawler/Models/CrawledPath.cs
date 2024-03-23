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
        public HashSet<IVertex> Vertices { get; set; }
        public HashSet<IEdge> Edges { get; set; }
        public TimeSpan ProcessingTime {  get; set; }

        public CrawledPath()
        {
            Vertices = new HashSet<IVertex>();
            Edges = new HashSet<IEdge>();
        }

        public CrawledPath(ICrawledPath path)
        {
            Edges = new HashSet<IEdge>(path.Edges);
            Vertices = new HashSet<IVertex>(path.Vertices);
        }
    }
}
