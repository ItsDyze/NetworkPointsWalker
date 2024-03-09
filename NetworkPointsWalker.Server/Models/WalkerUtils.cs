namespace NetworkPointsWalker.Server.Models
{
    public class Vertex
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double HeuristicValue { get; set; }
    }

    public class Edge
    {
        public Guid Id { get; set; }
        public Guid VertexA { get; set; }
        public Guid VertexB { get; set; }
        public double HeuristicValue { get; set; }

        internal Guid TheOtherVertex(Guid vertexId)
        {
            return VertexA == vertexId ? VertexB : VertexA;
        }
    }
}
