using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_Problems.GraphTheory
{
    class Vertex 
    {
        //public int index { get; set; }
        public List<int> Edges { get; set; }

        public Vertex()
        {
            Edges = new List<int>();
        }        
    }

    class DAG
    {
        public Vertex[] Vertices { get; set; }

        public DAG(int vertices)
        {
           this.Vertices = new Vertex[vertices];

        }

        public void AddVertices(int index, int edge)
        {
            this.Vertices[index].Edges.Add(edge);
        }

    }
}
