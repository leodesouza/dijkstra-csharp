using System.Runtime.InteropServices;

namespace dijkstra.Structure
{
    public class Graph
    {
        public int NumberVertices = 4;
        public List<List<Tuple<int,int>>> Create()
        {            
            var graph = new List<List<Tuple<int, int>>>(NumberVertices);

            for(int i = 0; i < NumberVertices; i++){
                graph.Add(new List<Tuple<int, int>>());
            }

            //First node
            graph[0].Add(new Tuple<int, int>(1, 9));
            graph[0].Add(new Tuple<int, int>(2, 14));
            graph[0].Add(new Tuple<int, int>(3, 15));

            return graph;

        }
    }
}