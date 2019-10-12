using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            this.Data = data;
            Left = null;
            Right = null;            
        }
    }
}
