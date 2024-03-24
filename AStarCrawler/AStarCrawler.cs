using AStarCrawler.Interfaces;
using System.Collections.Concurrent;

namespace AStarCrawler
{
    public class AStarCrawler : IAStarCrawler
    {
        public ICrawledPath? GetShortestPath(Guid from, Guid to, HashSet<IEdge> edges, HashSet<IVertex> vertices)
        {
            return GetPaths(from, to, edges, vertices, true, false).SingleOrDefault();
        }

        public IEnumerable<ICrawledPath> GetShortestPathAndCandidates(Guid from, Guid to, HashSet<IEdge> edges, HashSet<IVertex> vertices)
        {
            return GetPaths(from, to, edges, vertices, true, true);
        }

        public IEnumerable<ICrawledPath> GetAllPaths(Guid from, Guid to, HashSet<IEdge> edges, HashSet<IVertex> vertices, bool includeCandidates)
        {
            return GetPaths(from, to, edges, vertices, false, includeCandidates);
        }

        private IEnumerable<ICrawledPath> GetPaths(Guid from, Guid to, HashSet<IEdge> edges, HashSet<IVertex> vertices, bool onlyFirstPath = false, bool includeCandidates = false)
        {
            var awaitingInstances = new ConcurrentBag<IAStarInstance>();

            var startVertex = vertices.Single(x => x.Id == from);
            var endVertex = vertices.Single(x => x.Id == to);


            IAStarInstance firstInstance = new AStarInstance(startVertex, endVertex, vertices, edges);
            awaitingInstances.Add(firstInstance);

            bool foundPath;
            while (awaitingInstances.Count(instance => !instance.IsDone) > 0)
            {
                foundPath = false;
                IAStarInstance crawlerToProcess = FindInstanceToProcess(awaitingInstances);
                IEnumerable<IAStarInstance> newInstances;

                foundPath = crawlerToProcess.Run(out newInstances);
                var crawledPath = crawlerToProcess.Path;

                foreach (var instance in newInstances)
                {
                    if (includeCandidates)
                    {
                        yield return instance.Path;
                    }
                    awaitingInstances.Add(instance);
                }

                if (foundPath)
                {
                    yield return crawledPath;

                    if(onlyFirstPath)
                    {
                        yield break;
                    }
                }

            }
        }

        private static IAStarInstance FindInstanceToProcess(ConcurrentBag<IAStarInstance> awaitingInstances)
        {
            var minHeuristic = awaitingInstances.Where(x => !x.IsDone).Min(x => x.InvertHeuristicValue);
            var crawlerToProcess = awaitingInstances.First(y => !y.IsDone && y.InvertHeuristicValue == minHeuristic);
            return crawlerToProcess;
        }
    }
}
