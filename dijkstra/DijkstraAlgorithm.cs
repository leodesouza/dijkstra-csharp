using System.Security;
using dijkstra.Structure;

namespace dijkstra
{
    public class DijkstraAlgorithm
    {
        Graph _graph;
        public DijkstraAlgorithm()
        {
            _graph = new Graph();
        }
        public void Execute()
        {

            int source = 0;
            var graph = _graph.Create();

            int verticesCount = graph.Count();
            int[] distances = new int[verticesCount];
            bool[] processed = new bool[verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                distances[i] = int.MaxValue;
                processed[i] = false;
            }

            distances[source] = 0;

            // Find the shortest path 
            for (int count = 0; count < verticesCount - 1; count++)
            {
                var minDistanceIndex = MinDistance(distances, processed, verticesCount);
                processed[minDistanceIndex] = true;

                foreach(Tuple<int, int> neighbor in graph[minDistanceIndex]){
                    int vertice = neighbor.Item1;                    
                    int distance = neighbor.Item2;
                    if(!processed[vertice] && distances[minDistanceIndex] != int.MaxValue 
                            && distances[minDistanceIndex] + distance < distances[vertice])
                    {
                        distances[vertice] = distances[minDistanceIndex] + distance;
                    }
                }
                
            }

            PrintDistances(distances, verticesCount);
        }

        public int MinDistance(int[] distance, bool[] processed, int verticesCount)
        {

            int min = int.MaxValue;
            int minIndex = -1;
            for (int vertice = 0; vertice < verticesCount; ++vertice)
            {
                if (!processed[vertice] && distance[vertice] < min)
                {
                    min = distance[vertice];
                    minIndex = vertice;
                }
            }

            return minIndex;

        }

        public void PrintDistances(int[] distances, int verticesCount)
        {

            for (int i = 0; i < verticesCount; i++)
            {
                Console.WriteLine(i + " \t " + distances[i]);
            }
        }
    }
}