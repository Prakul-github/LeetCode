using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_Problems.GraphTheory
{
    class Vertice 
    {
        //public int index { get; set; }
        public List<int> Edges { get; set; }

        public Vertice()
        {
            Edges = new List<int>();
        }        
    }

    class DAG
    {
        public Vertice[] Vertices { get; set; }

        public DAG(int vertices)
        {
           this.Vertices = new Vertice[vertices];

        }

        public void AddVertices(int index, int edge)
        {
            this.Vertices[index].Edges.Add(edge);
        }

    }
}
