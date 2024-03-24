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
        IList<IEdge> Edges { get; set; }
        IList<IVertex> Vertices { get; set; }
        TimeSpan ProcessingTime { get; set; }
        bool IsValidSolution { get; set; }

    }
}
