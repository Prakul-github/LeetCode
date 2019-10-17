using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// 797. All Paths From Source to Target
/// </summary>
namespace LeetCodeProblems
{
    public class Solution
    {
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            int vertices = graph.Length;
            //int edges = graph.GetUpperBound(1);
            DAG DAGgraph = new DAG(vertices);
            int index = 0;

            foreach(int[] subArray in graph)
            {
                Vertex Vertex = new Vertex();

                // sort sub Array

                foreach (int item in subArray)
                {
                    Vertex.Edges.Add(item);
                }

                DAGgraph.Vertices[index++] = Vertex;
            }

            IList<IList<int>> results = new List<IList<int>>();
            IList<int> currentSol = new List<int>();
            currentSol.Add(0);

            TraverseGraph(DAGgraph, results, currentSol, 0);

            return results;            
        }

        private void TraverseGraph(DAG DAGgraph, IList<IList<int>> solutions, IList<int> currentSol, int index)
        {
            if(DAGgraph.Vertices[index].Edges.Count == 0)
            {               
                solutions.Add(currentSol);
                currentSol = null;
                return;
            }

            List<int> edges = DAGgraph.Vertices[index].Edges;

            foreach (int edge in edges)
            {
                List<int> newSolution = new List<int>();

                foreach(int e in currentSol)
                {
                    newSolution.Add(e);
                }

                newSolution.Add(edge);

                TraverseGraph(DAGgraph, solutions, newSolution, edge);
            }
        }
    }
}
