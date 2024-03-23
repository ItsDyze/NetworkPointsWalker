using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Interfaces
{
    public interface ICrawledPath
    {
        HashSet<IEdge> Edges { get; set; }
        HashSet<IVertex> Vertices { get; set; }
        TimeSpan ProcessingTime { get; set; }

    }
}
