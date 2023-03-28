using System.Runtime.InteropServices;

namespace _01.Red_Black_Tree
{
    using System;
    using System.Collections.Generic;

    public class RedBlackTree<T>
        : IBinarySearchTree<T> where T : IComparable
    {
        private const bool Red = true;
        private const bool Black = false;
        private Node root;

        public RedBlackTree()
        {

        }

        public int Count
        {
            get => this.root != null ? this.root.Count : 0;
        }

        public void Insert(T element)
        {
            this.root = this.InsertPrivate(element, this.root);
            this.root.Color = Black;
        }

        public T Select(int rank)
        {
            Node node = this.SelectPrivate(rank, this.root);
            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;

        }



        public int Rank(T element)
        {
            return this.RankPrivate(element, this.root);
        }

        private int RankPrivate(T element, Node node)
        {
            if (node == null)
            {
                return 0;

            }

            int comp = element.CompareTo(node.Value);

            if (comp < 0)
            {
                return this.RankPrivate(element, node.Left);
            }

            if (comp > 0)
            {
                return 1 + this.GetCount(node.Left) + this.RankPrivate(element, node.Right);
            }

            return GetCount(node.Left);
        }

        public bool Contains(T element)
        {
            Node node = this.FindNode(this.root, element);
            return node != null;
        }

        private Node FindNode(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.Equals(element))
            {
                return node;
            }

            int comp = element.CompareTo(node.Value);

            if (comp > 0)
            {
                node = this.FindNode(node.Right, element);
            }

            if (comp < 0)
            {
                node = this.FindNode(node.Left, element);
            }

            return node;

        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node node = this.FindNode(this.root, element);

            RedBlackTree<T> tree = new RedBlackTree<T>();

            tree.root = node;

            return tree;
        }

        public void DeleteMin()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMinPrivate(this.root);
        }



        public void DeleteMax()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMaxPrivate(this.root);
        }



        public IEnumerable<T> Range(T startRange, T endRange)
        {
            return null;
        }

        public void Delete(T element)
        {
            this.root = this.DeletePrivate(this.root, element);
        }



        public T Ceiling(T element)
        {
            return Select(Rank(element) + 1);
        }

        public T Floor(T element)
        {
            return Select(Rank(element) - 1);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrderPrivate(action, this.root);
        }

        private void EachInOrderPrivate(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;

            }

            this.EachInOrderPrivate(action,node.Left);

            action.Invoke(node.Value);

            this.EachInOrderPrivate(action,node.Right);
        }

        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Red;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Count { get; set; }

            public bool Color { get; set; }


        }

        private bool IsRed(Node node)
        {
            return node != null && node.Color == Red;
        }

        private void FlipColor(Node node)
        {
            node.Color = Red;
            node.Left.Color = Black;
            node.Right.Color = Black;
        }

        private Node RotateRight(Node node)
        {
            Node temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            temp.Color = node.Color;
            node.Color = Red;

            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return temp;

        }

        private Node RotateLeft(Node node)
        {
            Node temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;

            temp.Color = node.Color;
            node.Color = Red;

            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return temp;
        }

        private int GetCount(Node node)
        {

            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        private Node InsertPrivate(T element, Node node)
        {
            if (node == null)
            {
                return new Node(element) { Count = 1 };
            }


            var comp = element.CompareTo(node.Value);

            if (comp > 0)
            {
                node.Right = this.InsertPrivate(element, node.Right);
            }
            else if (comp < 0)
            {
                node.Left = this.InsertPrivate(element, node.Left);
            }

            if (this.IsRed(node.Right) && !this.IsRed(node.Left))
            {
                node = this.RotateLeft(node);
            }

            if (this.IsRed(node.Left) && this.IsRed(node.Left.Left))
            {
                node = this.RotateRight(node);
            }

            if (this.IsRed(node.Left) && this.IsRed(node.Right))
            {
                this.FlipColor(node);
            }

            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return node;

        }

        private Node DeleteMaxPrivate(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = this.DeleteMaxPrivate(node.Right);
            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return node;
        }

        private Node DeleteMinPrivate(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = this.DeleteMinPrivate(node.Left);
            node.Count = 1 + this.GetCount(node.Left) + this.GetCount(node.Right);

            return node;
        }

        private Node DeletePrivate(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }

            int comp = element.CompareTo(node.Value);

            if (comp < 0)
            {
                node = this.DeletePrivate(node.Left, element);
            }
            else if (comp > 0)
            {
                node = this.DeletePrivate(node.Right, element);
            }
            else
            {
                if (node.Right == null)
                {
                    return node.Left;
                }

                if (node.Left == null)
                {
                    return node.Right;
                }

                Node temp = node;
                node = this.FindMin(temp.Right);
                node.Right = this.DeleteMinPrivate(temp.Right);
                node.Left = temp.Left;
            }

            node.Count = this.GetCount(node.Left) + this.GetCount(node.Right) + 1;

            return node;
        }

        private Node FindMin(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }



            return FindMin(node.Left);

        }

        private Node SelectPrivate(int rank, Node node)
        {
            if (node == null)
            {
                return null;
            }

            int leftCount = this.GetCount(node.Left);

            if (leftCount == rank)
            {
                return node;
            }

            if (leftCount > rank)
            {
                return this.SelectPrivate(rank, node.Left);
            }

            return SelectPrivate(rank - (leftCount + 1), node.Right);

        }
    }
}