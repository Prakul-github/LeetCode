using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
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
                    int cost = edge.Cost;

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

        /// <summary>
        /// Floyd-Warshall Algorithm is best suited for dense graphs since its complexity depends only on the number of vertices in the graph.
        /// For sparse graphs, Johnson’s Algorithm is more suitable.
        /// A dense graph is a graph in which the number of edges is close to the maximal number of edges. 
        /// The opposite, a graph with only a few edges, is a sparse graph.
        /// 
        /// Step-01:         
        /// Remove all the self loops and parallel edges(keeping the edge with lowest weight) from the graph if any.
        /// In our case, we don’t have any self edge and parallel edge.
        /// 
        /// Step-02:
        /// Now, write the initial distance matrix representing the distance between every pair of vertices 
        /// as mentioned in the given graph in the form of weights.
        /// For diagonal elements (representing self-loops), value = 0
        /// For vertices having a direct edge between them, value = weight of that edge
        /// For vertices having no direct edges between them, value = ∞
        /// 
        /// Step-03:
        /// From step-03, we will start our actual solution.
        /// 
        /// https://www.gatevidyalay.com/algorithms/
        /// </summary>
        /// <param name="graph">n*n matrix</param>
        /// <param name="source"></param>
        /// <param name="vertextCount"></param>
        /// <returns></returns>
        public List<int[,]> FloydWarshall_AllpairsShortestPath(int[,] graph, int vertextCount)
        {
            List<int[,]> allPairsShortestPaths = new List<int[,]>();
            
            // set infinity for values that are zero
            Helper.MarkNoDirectEdges(graph, vertextCount);

            int[,] previousMatrix = graph;

            // Loop through all the vertext to get shortest path for each vertext
            for (int i = 0; i < vertextCount; i++)
            {
                int[,] matrix = new int[vertextCount,vertextCount];
                                
                Helper.Copy2DArray(previousMatrix, matrix, vertextCount);

                for (int row = 0; row < vertextCount; row++)
                {
                    for(int col = 0; col < vertextCount; col++)
                    {
                        if (row == col)
                        {
                            matrix[row, col] = 0;
                        }
                        else if (previousMatrix[row, i] != int.MaxValue && previousMatrix[i, col] != int.MaxValue)
                        {
                            if (matrix[row, col] > previousMatrix[row, i] + previousMatrix[i, col])
                            {

                                matrix[row, col] = previousMatrix[row, i] + previousMatrix[i, col];
                            }
                        }
                    }
                }

                allPairsShortestPaths.Add(matrix);

                previousMatrix = matrix;
            }

            return allPairsShortestPaths;
        }

        public int[,] PrimAlgo_MinimumSpanningTree(int[,] graph, int source, int vertexCount)
        {
            int[,] minimumSpanningTree = new int[vertexCount, vertexCount];

            Helper.MarkNoDirectEdges(graph, vertexCount);

            Helper.Initialise2DArray(minimumSpanningTree, vertexCount, 0);

            bool[] nodesVisited = new bool[vertexCount];

            Helper.Initialise1DArray(nodesVisited, vertexCount, false);

            UpdateShortestEdge(minimumSpanningTree, graph, nodesVisited, source, vertexCount);

            return minimumSpanningTree;
        }

        private void UpdateShortestEdge(int[,] minimumSpanningTree, int[,] graph, bool[] nodesVisited, int currentNode, int vertexCount)
        {
            if(nodesVisited[currentNode] == true)
            {
                return;
            }

            nodesVisited[currentNode] = true;
            int minimumWeight = int.MaxValue;
            int shortestAdjacentNode = -1;

            for (int iLoop = 0; iLoop < vertexCount; iLoop++)
            {
                if (nodesVisited[iLoop] == false)
                    continue;

                for (int adjacentNode = 0; adjacentNode < vertexCount; adjacentNode++)
                {
                    if (iLoop == adjacentNode) continue;

                    if (graph[iLoop, adjacentNode] < minimumWeight && nodesVisited[adjacentNode] == false)
                    {
                        currentNode = iLoop;
                        minimumWeight = graph[currentNode, adjacentNode];
                        shortestAdjacentNode = adjacentNode;
                    }
                }
            }

            if (shortestAdjacentNode != -1)
            {
                minimumSpanningTree[currentNode, shortestAdjacentNode] = graph[currentNode, shortestAdjacentNode];

                UpdateShortestEdge(minimumSpanningTree, graph, nodesVisited, shortestAdjacentNode, vertexCount);
            }
        }
     
        public int[,] KruskalAlgo_MinimumSpanningTree(int[,] graph, int vertexCount)
        {
            int[,] minimumSpanningTree = new int[vertexCount, vertexCount];

            Helper.Initialise2DArray(minimumSpanningTree, vertexCount, int.MaxValue);

            List<Edge> edges = GetEdges(graph, vertexCount);
            edges = GetSortedEdges(edges);

            foreach(Edge edge in edges)
            {
                if(minimumSpanningTree[edge.Source, edge.Destination] > edge.Cost)
                {

                }
            }

            return minimumSpanningTree;
        }

        private List<Edge> GetSortedEdges(List<Edge> edges)
        {
            List<Edge> sortedEdges = new List<Edge>();

            while(edges.Count > 0 )
            {
                Edge edge = edges[0];
                edges.RemoveAt(0);
                sortedEdges = InsertionSort(sortedEdges, edge);
            }

            return sortedEdges;
        }

        private List<Edge> InsertionSort(List<Edge> edges, Edge edge)
        {
            List<Edge> sortedEdges = new List<Edge>();

            if (edges.Count == 0)
            {
                sortedEdges.Add(edge);
            }

            foreach(Edge e in edges)
            {
                if(e.Cost < edge.Cost)
                {
                    sortedEdges.Add(e);
                }
                else
                {
                    sortedEdges.Add(edge);
                    sortedEdges.Add(e);
                }
            }

            return sortedEdges;
        }

        

    }
}
