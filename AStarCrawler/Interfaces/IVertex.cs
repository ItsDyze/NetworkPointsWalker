using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Interfaces
{
    public interface IVertex
    {
        public Guid Id { get; }

        /// <summary>
        /// Value to order vertices viability. Lowest the better.
        /// </summary>
        public double InvertHeuristicValue { get; set; }
    }
}
