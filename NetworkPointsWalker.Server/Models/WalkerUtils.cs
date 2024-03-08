﻿namespace NetworkPointsWalker.Server.Models
{
    public class Vertex
    {
        public Guid Id { get; set; }
        public int HeuristicValue { get; set; }
    }

    public class Edge
    {
        public Guid Id { get; set; }
        public Guid VertexA { get; set; }
        public Guid VertexB { get; set; }

    }
}
