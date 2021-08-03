using System;
using System.Collections.Generic;

namespace Practice
{
    public class BT<T>
    {
        public BT(Node<T> root)
        {
            this.Root = root;

        }

        public T Value { get; set; }

        public Node<T> Root { get; set; }

        public string PreOrderDfs(Node<T> binaryNode, int indent)
        {
            string result = $"{new string(' ', indent)}{binaryNode.Value}\n";

            if (binaryNode.LeftChild != null)
            {
                result += this.PreOrderDfs(binaryNode.LeftChild, indent + 3);
            }

            if (binaryNode.RightChild != null)
            {
                result += this.PreOrderDfs(binaryNode.RightChild, indent + 3);

            }

            return result;
        }

        public string InOrderDfs(Node<T> binaryNode, int indent)
        {
            string result = "";

            if (binaryNode.LeftChild != null)
            {
                result += this.InOrderDfs(binaryNode.LeftChild, indent + 3);
            }

            result += $"{new string(' ', indent)}{binaryNode.Value}\n";


            if (binaryNode.RightChild != null)
            {
                result += this.InOrderDfs(binaryNode.RightChild, indent + 3);
            }

            return result;
        }

        public string PostOrderDfs(Node<T> binaryNode, int indent)
        {
            string result = "";

            if (binaryNode.LeftChild != null)
            {
                result += this.PostOrderDfs(binaryNode.LeftChild, indent + 3);
            }



            if (binaryNode.RightChild != null)
            {
                result += this.PostOrderDfs(binaryNode.RightChild, indent + 3);

            }

            result += $"{new string(' ', indent)}{binaryNode.Value}\n";


            return result;
        }

        public int PreOrderDfsSum(Node<T> binaryNode)
        {
            int result = Convert.ToInt32(binaryNode.Value);

            int childSum = 0;

            if (binaryNode.LeftChild != null)
            {
                childSum +=(this.PreOrderDfsSum(binaryNode.LeftChild));
            }

            if (binaryNode.RightChild != null)
            {
                childSum += (this.PreOrderDfsSum(binaryNode.RightChild));
            }

            return result+childSum;
        }

       

        public void PreOrderDfsListOfNodes(Node<T> binaryNode,List<T> list)
        {
            list.Add(binaryNode.Value);

            if (binaryNode.LeftChild != null)
            {
               this.PreOrderDfsListOfNodes(binaryNode.LeftChild,list);
            }

            if (binaryNode.RightChild != null)
            {
                this.PreOrderDfsListOfNodes(binaryNode.RightChild,list);

            }

           
        }
    }
}