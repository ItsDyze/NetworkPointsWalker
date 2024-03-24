using AStarCrawler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler.Tests.Models
{
    internal class Vertex : IVertex
    {
        public Guid Id { get; set; }

        public double InvertHeuristicValue { get; set; }
    }
}
