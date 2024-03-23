using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Interfaces
{
    public interface IAStarInstance
    {
        public bool IsDone { get; }
        public double InvertHeuristicValue { get; }
        public ICrawledPath Path { get; }
        public bool Run(out IEnumerable<IAStarInstance> newInstances);
    }
}
