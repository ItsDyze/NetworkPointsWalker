using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Interfaces
{
    public interface IAStarCrawler
    {
        public ICrawledPath GetShortestPath(Guid from, Guid to, HashSet<IEdge> edges, HashSet<IVertex> vertices);
    }
}
