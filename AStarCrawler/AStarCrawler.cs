using AStarCrawler.Interfaces;
using System.Collections.Concurrent;

namespace AStarCrawler
{
    public class AStarCrawler : IAStarCrawler
    {
        public ICrawledPath GetShortestPath(Guid from, Guid to, HashSet<IEdge> edges, HashSet<IVertex> vertices)
        {
            var awaitingInstances = new ConcurrentBag<IAStarInstance>();

            var startVertex = vertices.Single(x => x.Id == from);
            var endVertex = vertices.Single(x => x.Id == to);


            IAStarInstance firstInstance = new AStarInstance(startVertex, endVertex, vertices, edges, new HashSet<Guid>());
            awaitingInstances.Add(firstInstance);

            bool foundPath = false;
            while (awaitingInstances.Count(instance => !instance.IsDone) > 0 && !foundPath)
            {
                IAStarInstance crawlerToProcess = FindCrawlerToProcess(awaitingInstances);
                IEnumerable<IAStarInstance> newInstances;

                foundPath = crawlerToProcess.Run(out newInstances);

                if (foundPath)
                {
                    var crawledPath = crawlerToProcess.Path;
                    return crawledPath;
                }
                else
                {
                    awaitingInstances.Concat(newInstances);
                }
            }

            return null;
        }

        private static IAStarInstance FindCrawlerToProcess(ConcurrentBag<IAStarInstance> awaitingInstances)
        {
            var minHeuristic = awaitingInstances.Where(x => !x.IsDone).Min(x => x.InvertHeuristicValue);
            var crawlerToProcess = awaitingInstances.First(y => !y.IsDone && y.InvertHeuristicValue == minHeuristic);
            return crawlerToProcess;
        }
    }
}
