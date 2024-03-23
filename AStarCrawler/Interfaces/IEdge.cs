using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Interfaces
{
    public interface IEdge
    {
        public Guid Id { get; }
        public Guid VertexA { get; }
        public Guid VertexB { get; }

    }
}
