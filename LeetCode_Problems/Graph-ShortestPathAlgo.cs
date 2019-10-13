using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_Problems
{
    struct Edge
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Cost { get; set; }

        public Edge(int source, int destination, int cost)
        {
            Source = source;
            Destination = destination;
            Cost = cost;
        }
    }

    class ShortedPathAlgo
    {
        /// <summary>
        /// Greedy Algorithm
        /// Single source Shortest Path Algo
        /// Doesn't work if there is a negative edge in the graph
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="source"></param>
        /// <param name="vertexCount"></param>
        /// <returns></returns>
        public int[] Dijkstra_ShortestPath(int[,] graph, int source, int vertexCount)
        {
            int[] distance = new int[vertexCount];
            bool[] nodesVisited = new bool[vertexCount];
            
            for(int iLoop = 1; iLoop < vertexCount; iLoop++)
            {
                distance[iLoop] = int.MaxValue;
                nodesVisited[iLoop] = false;
            }

            distance[source] = 0;
            
            for (int iLoop = 0; iLoop < vertexCount - 1; iLoop++)
            {                
                int minAdjacentEdge = ShortestEdge(distance, nodesVisited, vertexCount);
                nodesVisited[minAdjacentEdge] = true;

                for (int jLoop = 0; jLoop < vertexCount; jLoop++)
                {
                    if (nodesVisited[jLoop] == false && graph[minAdjacentEdge, jLoop] != 0 && distance[minAdjacentEdge] != int.MaxValue && distance[minAdjacentEdge] + graph[minAdjacentEdge, jLoop] < distance[jLoop])
                    {
                        distance[jLoop] = distance[minAdjacentEdge] + graph[minAdjacentEdge, jLoop];
                    }
                }

                //Helper.PrintArray(distance);
                //Console.WriteLine("------------------------");
            }
            return distance;
        }

        public int ShortestEdge(int[] distance, bool[] nodesVisited, int vertexCount)
        {
            int min = int.MaxValue;
            int minEdge = 0;

            for(int iLoop = 0; iLoop < vertexCount; iLoop++)
            {
                if (distance[iLoop] <= min && nodesVisited[iLoop] == false)
                {
                    min = distance[iLoop];
                    minEdge = iLoop;
                }
            }

            return minEdge;
        }

        /// <summary>
        /// Dynamic Programming
        /// Single source shortest path
        /// Works for graph with negative edge, provided the total weight of the cycle is NOT negative.
        /// https://www.youtube.com/watch?v=l4-L1fMKaTY
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="source"></param>
        /// <param name="vertexCount"></param>
        /// <returns></returns>
        public int[] BellmanFord_ShortestPath(int[,] graph, int source, int vertexCount)
        {
            List<Edge> edges = GetEdges(graph, vertexCount);
            int[] distance = new int[vertexCount];

            for (int iLoop = 1; iLoop < vertexCount; iLoop++)
            {
                distance[iLoop] = int.MaxValue;
            }

            distance[0] = 0;

            for (int iLoop = 0; iLoop < vertexCount - 1; iLoop++)
            {
                foreach(Edge edge in edges)
                {
                    int u = edge.Source;
                    int v = edge.Destination;
                    int cost = edge.Destination;

                    if(distance[u] + cost < distance[v] && distance[u] != int.MaxValue)
                    {
                        distance[v] = distance[u] + cost;
                    }                    
                }
            }

            return distance;
        }

        private List<Edge> GetEdges(int[,] graph, int vertextCount)
        {
            List<Edge> edges = new List<Edge>();

            for(int row = 0; row < vertextCount; row++)
            {
                for(int col = 0; col < vertextCount; col++)
                {
                    if(graph[row, col] != 0)
                    {
                        edges.Add(new Edge(row, col, graph[row, col]));
                    }
                }
            }

            return edges;
        }
    }
}
