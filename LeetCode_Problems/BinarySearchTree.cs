using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems
{
    public enum Direction
    {
        Left,
        Right,
        None
    }

    class BinarySearchTree
    {
        private Node root;

        public bool InsertNode(int data)
        {
            if(root == null)
            {
                root = new Node(data);
                return true;
            }

            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(root);

            while(nodes.Count > 0)
            {
                Node node = nodes.Dequeue();

                if (data == node.Data)
                {
                    return false;
                }
                else if (data < node.Data)
                {
                    if(node.Left == null)
                    {
                        node.Left = new Node(data);
                    }
                    else
                    {
                        nodes.Enqueue(node.Left);
                    }
                }
                else
                {
                    if(node.Right == null)
                    {
                        node.Right = new Node(data);
                    }
                    else
                    {
                        nodes.Enqueue(node.Right);
                    }
                }
            }

            return true;
        }

        public void CreateBinaryTree(int[] elements)
        {
            foreach (int element in elements)
            {
                InsertNode(element);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True if element is found and deleted, false if element is not found or tree is empty.</returns>
        public bool DeleteData(int data)
        {             
            if(root == null)
            {
                return false;
            }
            else if (root.Data == data)
            {
                DeleteNode(null, root, Direction.None); //, Direction.None);
                return true;
            }

            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(root);

            while (nodes.Count != 0)
            {
                Node currentNode = nodes.Dequeue();

                if(currentNode == null)
                {
                    continue;
                }

                if (currentNode.Left != null && currentNode.Left.Data == data)
                {
                    DeleteNode(currentNode, currentNode.Left, Direction.Left);
                    return true;
                }
                else if (currentNode.Right != null && currentNode.Right.Data == data)
                {
                    DeleteNode(currentNode, currentNode.Right, Direction.Right);
                    return true;
                }
                                
                nodes.Enqueue(currentNode.Left);
                nodes.Enqueue(currentNode.Right);                
            }

            return false;
        }

        public void DeleteNode(Node parent, Node current, Direction direction)
        {
            if(current.Right == null && current.Left == null)
            {
                if(direction == Direction.Left)
                {
                    parent.Left = null;
                }
                else if (direction == Direction.Right)
                {
                    parent.Right = null;
                }
                else
                {
                    root = null;
                }
                
                return;
            }

            if(current.Right != null)
            {
                current.Data = MinValue(current, current.Right);
            }
            else if(current.Left != null)
            {
                current.Data = MaxValue(current, current.Left);                
            }
        }

        private int MaxValue(Node parent, Node current)
        {
            while(current.Right != null)
            {
                parent = current;
                current = current.Right;
            }

            int tempData = current.Data;
            parent.Right = null;

            return tempData;
        }

        private int MinValue(Node parent, Node current)
        {
            while (current.Left != null)
            {
                parent = current;
                current = current.Left;
            }

            int tempData = current.Data;
            parent.Left = null;

            return current.Data;
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

                if (current == null)
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


    }
}
