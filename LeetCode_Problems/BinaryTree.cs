using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    class BinaryTree
    {
        //List<Node> binaryTreeNodes = new List<Node>();

        public Node root;        
        
        public BinaryTree(int data)
        {
            this.root = new Node(data);
        }

        public BinaryTree()
        {
            this.root = null;
        }

        public void InsertNode(int data)
        {
            if (root == null)
            { 
                root = new Node(data);
                return;
            }
            else
            {
                Queue<Node> nodes = new Queue<Node>();
                nodes.Enqueue(root);

                bool flagNodeInserted = false;

                while(flagNodeInserted == false)
                {
                    Node current = nodes.Dequeue();

                    if(current.Left == null)
                    {
                        current.Left = new Node(data);
                        flagNodeInserted = true;
                        break;
                    }
                    else if (current.Right == null)
                    {
                        current.Right = new Node(data);
                        flagNodeInserted = true;
                        break;
                    }

                    if (current.Left != null)
                    {
                        nodes.Enqueue(current.Left);
                    }

                    if(current.Right != null)
                    {
                        nodes.Enqueue(current.Right);
                    }
                }                
            }

        }

        public void CreateBinaryTree(int[] elements)
        {
            foreach(int element in elements)
            {
                InsertNode(element);
            }
        }

        public StringBuilder PrintBinaryTree()
        {
            StringBuilder result = new StringBuilder();
            Queue<Node> queueNodes = new Queue<Node>();
            queueNodes.Enqueue(root);
            queueNodes.Enqueue(null);
                        
            while (queueNodes.Count != 0)
            {
                Node current = queueNodes.Dequeue();
                
                if(current == null)
                {
                    result.Append("\n");

                    if (queueNodes.Count != 0)
                    {
                        queueNodes.Enqueue(null);
                    }
                }
                else
                {
                    result.Append(current.Data);

                    if (current.Left != null)
                    {
                        queueNodes.Enqueue(current.Left);
                    }

                    if (current.Right != null)
                    {
                        queueNodes.Enqueue(current.Right);
                    }
                }               
            }

            return result;
        }

        public void InsertNode(int data, Node current)
        {

        }
    }
}
