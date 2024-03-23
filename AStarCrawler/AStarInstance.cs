using AStarCrawler.Extensions;
using AStarCrawler.Interfaces;
using AStarCrawler.Models;
using AStarCrawler.Queries;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AStarCrawler
{
    public class AStarInstance : IAStarInstance
    {

        private IVertex _startVertex;
        private IVertex _endVertex;
        private HashSet<IVertex> _vertices;
        private HashSet<IEdge> _edges;
        private HashSet<Guid> _exploredVertices;
        private ICrawledPath _currentPath;
        private bool _isDone = false;
        private double _invertHeuristicValue = 0;

        public bool IsDone => _isDone;
        public double InvertHeuristicValue => _invertHeuristicValue;
        public ICrawledPath Path => _currentPath;

        public AStarInstance(IVertex startVertex, IVertex endVertex, HashSet<IVertex> vertices, HashSet<IEdge> edges, HashSet<Guid> exploredVertices, ICrawledPath currentPath = null)
        {
            _invertHeuristicValue = startVertex.InvertHeuristicValue;
            _startVertex = startVertex;
            _endVertex = endVertex;
            _vertices = vertices;
            _edges = edges;
            _exploredVertices = exploredVertices;

            _currentPath = currentPath == null ? new CrawledPath() : currentPath;
            
        }

        public bool Run(out IEnumerable<IAStarInstance> newInstances)
        {
            _isDone = true;
            newInstances = new List<IAStarInstance>();
            _currentPath.Vertices.Add(_startVertex);

            if (_startVertex == _endVertex)
            {
                _exploredVertices.Add(_startVertex.Id);
                return true;
            }

            var relevantOrderedEdges = _edges.FromOrigin(_startVertex.Id)
                                                .NotExplored(_exploredVertices)
                                                .OrderBy(edge => _vertices.Single(vertex => vertex.Id == edge.GetOtherVertexId(_startVertex.Id)).InvertHeuristicValue);

            foreach (var edge in relevantOrderedEdges)
            {
                var newPath = new CrawledPath(_currentPath);
                newPath.Edges.Add(edge);

                var theOtherVertex = _vertices.Single(vertex => vertex.Id == edge.GetOtherVertexId(_startVertex.Id));
                newInstances.Append(new AStarInstance(theOtherVertex, _endVertex, _vertices, _edges, _exploredVertices, newPath));
            }

            _exploredVertices.Add(_startVertex.Id);
            return false;
        }
    }
}
